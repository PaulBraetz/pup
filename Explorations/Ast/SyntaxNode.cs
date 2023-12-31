namespace Ast;

abstract class SyntaxNode(SyntaxKind syntaxKind, Location location)
{
    public SyntaxKind SyntaxKind { get; } = syntaxKind;
    public Location Location { get; } = location;
    public abstract void AppendToOutput(IOutputBuilder builder);
}
