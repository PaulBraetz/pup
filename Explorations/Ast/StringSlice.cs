namespace Ast;

readonly record struct StringSlice(String Source, Int32 Start, Int32 Length)
{
    public ReadOnlySpan<Char> AsSpan() => Source.AsSpan(Start, Length);
    public override String ToString() => Source.Substring(Start, Length);
}
