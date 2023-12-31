
namespace Ast;

using System.Globalization;

sealed class IntegerLiteralExpression(SyntaxToken syntaxToken) :
    LiteralExpression<Int32>(
        SyntaxKind.IntegerLiteralExpression,
        Parse(syntaxToken),
        syntaxToken,
        syntaxToken.Location)
{
    private static Int32 Parse(SyntaxToken syntaxToken) =>
        syntaxToken.Text.Match(
            static s => Int32.Parse(s.AsSpan(), CultureInfo.InvariantCulture),
            static c => c - '0',
            static s => Int32.Parse(s, CultureInfo.InvariantCulture));
}
