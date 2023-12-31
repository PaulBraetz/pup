namespace Ast;

interface IOutputBuilder
{
    IOutputBuilder Append(SyntaxTokenText text);
    String Build(CancellationToken cancellationToken);
}