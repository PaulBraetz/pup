namespace Ast;

using RhoMicro.CodeAnalysis;

[UnionType(typeof(String))]
[UnionType(typeof(StringSlice))]
[UnionType(typeof(Char))]
[UnionTypeSettings(ToStringSetting = ToStringSetting.Simple)]
readonly partial struct SyntaxTokenText
{
    public static SyntaxTokenText Assignment = new(":=");
    public static SyntaxTokenText LeftBrace = new('{');
    public static SyntaxTokenText RightBrace = new('}');
    public static SyntaxTokenText LeftParenthesis = new('(');
    public static SyntaxTokenText RightParenthesis = new(')');
    public static SyntaxTokenText Semicolon = new(';');
    public static SyntaxTokenText Dereference = new('.');
    public static SyntaxTokenText Comma = new(',');
    public static SyntaxTokenText Empty = new(String.Empty);
}