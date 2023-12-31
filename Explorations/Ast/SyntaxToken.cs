namespace Ast;

readonly record struct SyntaxToken(SyntaxTokenText Text, SyntaxTokenKind SyntaxTokenKind, Location Location)
{
    public static SyntaxToken CreateName(SyntaxTokenText text) => new(text, SyntaxTokenKind.Name, Location.None);
    public static SyntaxToken CreateName(SyntaxTokenText text, Location location) => new(text, SyntaxTokenKind.Name, location);

    public static SyntaxToken CreateUnknown(SyntaxTokenText text) => new(text, SyntaxTokenKind.Unknown, Location.None);
    public static SyntaxToken CreateUnknown(SyntaxTokenText text, Location location) => new(text, SyntaxTokenKind.Unknown, location);

    public static SyntaxToken CreateIntegerLiteral(SyntaxTokenText text) => new(text, SyntaxTokenKind.IntegerLiteral, Location.None);
    public static SyntaxToken CreateIntegerLiteral(SyntaxTokenText text, Location location) => new(text, SyntaxTokenKind.IntegerLiteral, location);

    public static SyntaxToken CreateWhitespace(SyntaxTokenText text) => new(text, SyntaxTokenKind.Whitespace, Location.None);
    public static SyntaxToken CreateWhitespace(SyntaxTokenText text, Location location) => new(text, SyntaxTokenKind.Whitespace, location);

    public static SyntaxToken CreateAssignment() => new(SyntaxTokenText.Assignment, SyntaxTokenKind.Assignment, Location.None);
    public static SyntaxToken CreateAssignment(Location location) => new(SyntaxTokenText.Assignment, SyntaxTokenKind.Assignment, location);

    public static SyntaxToken CreateEmpty() => new(SyntaxTokenText.Empty, SyntaxTokenKind.Empty, Location.None);
    public static SyntaxToken CreateEmpty(Location location) => new(SyntaxTokenText.Empty, SyntaxTokenKind.Empty, location);

    public static SyntaxToken CreateSemicolon() => new(SyntaxTokenText.Semicolon, SyntaxTokenKind.Semicolon, Location.None);
    public static SyntaxToken CreateSemicolon(Location location) => new(SyntaxTokenText.Semicolon, SyntaxTokenKind.Semicolon, location);

    public static SyntaxToken CreateComma() => new(SyntaxTokenText.Comma, SyntaxTokenKind.Comma, Location.None);
    public static SyntaxToken CreateComma(Location location) => new(SyntaxTokenText.Comma, SyntaxTokenKind.Comma, location);

    public static SyntaxToken CreateDereference() => new(SyntaxTokenText.Dereference, SyntaxTokenKind.Dereference, Location.None);
    public static SyntaxToken CreateDereference(Location location) => new(SyntaxTokenText.Dereference, SyntaxTokenKind.Dereference, location);

    public static SyntaxToken CreateLeftBrace() => new(SyntaxTokenText.LeftBrace, SyntaxTokenKind.LeftBrace, Location.None);
    public static SyntaxToken CreateLeftBrace(Location location) => new(SyntaxTokenText.LeftBrace, SyntaxTokenKind.LeftBrace, location);

    public static SyntaxToken CreateRightBrace() => new(SyntaxTokenText.RightBrace, SyntaxTokenKind.RightBrace, Location.None);
    public static SyntaxToken CreateRightBrace(Location location) => new(SyntaxTokenText.RightBrace, SyntaxTokenKind.RightBrace, location);

    public static SyntaxToken CreateLeftParenthesis() => new(SyntaxTokenText.LeftParenthesis, SyntaxTokenKind.LeftParenthesis, Location.None);
    public static SyntaxToken CreateLeftParenthesis(Location location) => new(SyntaxTokenText.LeftParenthesis, SyntaxTokenKind.LeftParenthesis, location);

    public static SyntaxToken CreateRightParenthesis() => new(SyntaxTokenText.RightParenthesis, SyntaxTokenKind.RightParenthesis, Location.None);
    public static SyntaxToken CreateRightParenthesis(Location location) => new(SyntaxTokenText.RightParenthesis, SyntaxTokenKind.RightParenthesis, location);
}