
namespace Ast;

using System.Collections.Immutable;

sealed class FunctionDefinition(
    Maybe<SyntaxToken> semicolon,
    SyntaxToken name,
    SyntaxToken leftParenthesis,
    ImmutableArray<Parameter> parameters,
    SyntaxToken rightParenthesis,
    SyntaxToken assignment,
    Expression body) :
    SyntaxNode(SyntaxKind.FunctionDeclaration, semicolon.Bind(t => t.Location, name.Location))
{
    public Maybe<SyntaxToken> Semicolon { get; } = semicolon;
    public SyntaxToken Name { get; } = name;
    public SyntaxToken LeftParenthesis { get; } = leftParenthesis;
    public ImmutableArray<Parameter> Parameters { get; } = parameters;
    public SyntaxToken RightParenthesis { get; } = rightParenthesis;
    public SyntaxToken Assignment { get; } = assignment;
    public Expression Body { get; } = body;

    public override void AppendToOutput(IOutputBuilder builder) =>
        builder.Append(Semicolon)
        .Append(Name)
        .Append(LeftParenthesis)
        .Append(Parameters)
        .Append(RightParenthesis)
        .Append(Assignment)
        .Append(Body);
}