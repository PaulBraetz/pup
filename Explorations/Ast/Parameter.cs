namespace Ast;

sealed class Parameter(Maybe<SyntaxToken> separator, SyntaxToken name) 
    : SyntaxNode(SyntaxKind.Parameter, separator.Bind(t=>t.Location, name.Location))
{
    public Maybe<SyntaxToken> Separator { get; } = separator;
    public SyntaxToken Name { get; } = name;

    public override void AppendToOutput(IOutputBuilder builder) =>
        builder.Append(Separator)
        .Append(Name);
}
