namespace Ast;

sealed class UnknownExpression(SyntaxToken syntaxToken)
    : Expression(SyntaxKind.UnknownExpression, syntaxToken.Location)
{
    public SyntaxToken SyntaxToken { get; } = syntaxToken;
    public override void AppendToOutput(IOutputBuilder builder) => builder.Append(SyntaxToken);
}