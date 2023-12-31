namespace Ast;

sealed class PrefixFunctionExpression(
    Maybe<SyntaxToken> separator,
    SyntaxToken name,
    SyntaxToken leftParenthesis,
    SyntaxTokenList arguments,
    SyntaxToken rightParenthesis)
    : Expression(SyntaxKind.PrefixFunctionExpression, separator.Bind(t => t.Location, name.Location))
{
    public Maybe<SyntaxToken> Separator { get; } = separator;
    public SyntaxToken Name { get; } = name;
    public SyntaxToken LeftParenthesis { get; } = leftParenthesis;
    public SyntaxTokenList Arguments { get; } = arguments;
    public SyntaxToken RightParenthesis { get; } = rightParenthesis;

    public override void AppendToOutput(IOutputBuilder builder) =>
        builder.Append(Separator)
        .Append(Name)
        .Append(LeftParenthesis)
        .Append(Arguments)
        .Append(RightParenthesis);
}
