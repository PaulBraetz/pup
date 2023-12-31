namespace Ast;

abstract class LiteralExpression<T>(SyntaxKind syntaxKind, T value, SyntaxToken syntaxToken, Location location)
    : Expression(syntaxKind, location)
{
    public T Value { get; } = value;
    public SyntaxToken SyntaxToken { get; } = syntaxToken;
    public override void AppendToOutput(IOutputBuilder builder) => builder.Append(SyntaxToken);
}