using Explorations.GreenThreads;

using System.Collections.Concurrent;

sealed class GreenThread<T> : IEquatable<GreenThread<T>?>
{
    private GreenThread(GreenThreadContext context) => Context = context;
    public GreenThreadContext Context { get; private set; }
    public GreenThreadResult<T> Result { get; private set; } = GreenThreadResult<T>.NonTerminated;
    public event EventHandler<GreenThreadResult<T>>? OnTerminated;

    private static Int32 _threadCount;
    private static readonly ConcurrentQueue<GreenThread<T>> _cache = new();

    private readonly AutoResetEvent _queueGate = new(false);

    public void Join() => _queueGate.WaitOne();

    private void Initialize()
    {
        _ = _queueGate.Reset();
        Result = GreenThreadResult<T>.NonTerminated;
    }
    private void Terminate()
    {
        try
        {
            OnTerminated?.Invoke(this, Result);
        } finally
        {
            _ = _queueGate.Set();
            _cache.Enqueue(this);
        }
    }

    public static GreenThread<T> Run(Func<GreenThreadContext, Task<T>> func, GreenThreadRunOptions? options = null)
    {
        var result = GetThread(options);
        _ = result.Enqueue(func);

        return result;
    }
    public static GreenThread<T> Run(Func<GreenThreadContext, T> func, GreenThreadRunOptions? options = null)
    {
        var result = GetThread(options);
        _ = result.Enqueue((c) => Task.Run(() => func(c)));

        return result;
    }

    private static GreenThread<T> GetThread(GreenThreadRunOptions? options = null)
    {
        options ??= GreenThreadRunOptions.Default;

        var cts = options.CtsFactory.Invoke() ?? throw GreenThreadRunException.NullCtsFactory(options);

        Int32 contextId;
        GreenThread<T> result;
        var dequeueAttempts = options.CacheRetries;
        if(dequeueAttempts < 0)
            throw GreenThreadRunException.NegativeRetries(options);

        do
        {
            if(dequeueAttempts > 0 && _cache.TryDequeue(out result))
            {
                result.Context = new GreenThreadContext(result.Context.Id, cts);
                return result;
            }

            dequeueAttempts -= 1;
            if(dequeueAttempts < 0)
                throw GreenThreadRunException.ThreadStarvation(options);

            contextId = Interlocked.Increment(ref _threadCount);
        } while(contextId < 0);

        var context = new GreenThreadContext(contextId, cts);
        result = new GreenThread<T>(context);

        return result;
    }

    private async Task Enqueue(Func<GreenThreadContext, Task<T>> func)
    {
        Initialize();
        try
        {
            var result = await func.Invoke(Context);
            Result = GreenThreadResult<T>.CreateFromResult(result);
        } catch(Exception ex)
        {
            Result = ex;
        } finally
        {
            Terminate();
        }
    }

    public override Boolean Equals(Object? obj) => Equals(obj as GreenThread<T>);
    public Boolean Equals(GreenThread<T>? other) => other is not null && EqualityComparer<GreenThreadContext>.Default.Equals(Context, other.Context);
    public override Int32 GetHashCode() => -59922564 + EqualityComparer<GreenThreadContext>.Default.GetHashCode(Context);

    public override String ToString() => $"{GetType()} {Context.Id}";
}