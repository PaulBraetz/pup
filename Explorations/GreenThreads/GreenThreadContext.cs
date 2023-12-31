readonly struct GreenThreadContext(Int32 id, CancellationTokenSource cancellation) : IEquatable<GreenThreadContext>
{
    public Int32 Id { get; } = id;
    public CancellationTokenSource Cancellation { get; } = cancellation;

    public override Boolean Equals(Object? obj) => obj is GreenThreadContext context && Equals(context);
    public Boolean Equals(GreenThreadContext other) => Id == other.Id;
    public override Int32 GetHashCode() => 2108858624 + Id.GetHashCode();

    public static Boolean operator ==(GreenThreadContext left, GreenThreadContext right) => left.Equals(right);
    public static Boolean operator !=(GreenThreadContext left, GreenThreadContext right) => !(left == right);

    public override String ToString() => $"{GetType()} {Id}";
}