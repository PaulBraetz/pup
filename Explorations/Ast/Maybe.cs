namespace Ast;
static class Maybe
{
    public static Maybe<T> Unit<T>() => new();
    public static Maybe<T> Unit<T>(T value) => new(value);
}
readonly struct Maybe<T>
{
    public Maybe(T value) : this()
    {
        _value = value;
        HasValue = true;
    }

    private readonly T _value;
    public T Value => HasValue ? _value : throw new InvalidOperationException($"Unable to access value of empty Maybe<{typeof(T).Name}>.");
    public Boolean HasValue { get; }

    public Maybe<TResult> Bind<TResult>(Func<T, TResult> projection) =>
        HasValue ?
        projection(_value) :
        new Maybe<TResult>();
    public TResult Bind<TResult>(Func<T, TResult> projection, TResult fallbackResult) =>
        HasValue ?
        projection(_value) :
        fallbackResult;

    public static implicit operator Maybe<T>(T value) => new(value);
}
