namespace Ast;
readonly record struct Location(Int32 Line, Int32 Character, File File)
{
    public static Location None { get; } = new(0, 0, File.None);
}
