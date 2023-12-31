namespace Ast;

using System.Collections.Immutable;
using System.Globalization;
using System.Linq.Expressions;

sealed class Program
{
    private static void Main(String[] _0)
    {
        var sf = SyntaxFactory.Default;
        //f(a,,b):=a+b
        var declaration = new FunctionDefinition(
            Maybe.Unit<SyntaxToken>(),
            SyntaxToken.CreateName('f'),
            SyntaxToken.CreateLeftParenthesis(),
            [sf.FirstParameter('a'), sf.EmptyParameter(), sf.Parameter('b')],
            SyntaxToken.CreateRightParenthesis(),
            SyntaxToken.CreateAssignment(),
            new UnknownExpression(SyntaxToken.CreateUnknown("a+b")));
        var result = new OutpuBuilder().Append(declaration).Build(default);
        Console.WriteLine(result);
    }
}

sealed class SyntaxFactory
{
    private SyntaxFactory() { }
    public static SyntaxFactory Default { get; } = new();
#pragma warning disable CA1822 // Mark members as static
    #region Parameter
    public Parameter FirstParameter(SyntaxTokenText nameText) =>
        new(Maybe.Unit<SyntaxToken>(), SyntaxToken.CreateName(nameText));
    public Parameter Parameter(SyntaxTokenText nameText) =>
        new(SyntaxToken.CreateComma(), SyntaxToken.CreateName(nameText));
    private static readonly Parameter _emptyParameter =
        new(SyntaxToken.CreateComma(), SyntaxToken.CreateEmpty());
    public Parameter EmptyParameter() => _emptyParameter;
    #endregion
    #region FunctionDeclaration
    public FunctionDefinition FunctionDeclaration(
        SyntaxTokenText nameText,
        ImmutableArray<Parameter> parameters,
        Expression body) =>
        new();
    #endregion
#pragma warning restore CA1822 // Mark members as static
}