sealed class GreenThreadRunOptions(Func<CancellationTokenSource> ctsFactory, Int32 cacheRetries)
{
    public static GreenThreadRunOptions Default { get; } =
        new(() => new CancellationTokenSource(), 16_384);
    /// <summary>
    /// Gets the factory to invoke when creating a <see cref="CancellationTokenSource"/> for newly scheduled green threads.
    /// </summary>
    public Func<CancellationTokenSource> CtsFactory { get; } = ctsFactory;
    /// <summary>
    /// Gets the amount of cache dequeueing retries afforded to scheduling green threads.
    /// </summary>
    public Int32 CacheRetries { get; } = cacheRetries;
}
