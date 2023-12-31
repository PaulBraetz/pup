namespace Ast;

using System.Collections.Immutable;

readonly struct SyntaxTokenList(ImmutableArray<SyntaxToken> tokens)
{
    public static SyntaxTokenList Empty { get; } = new([]);
    public ImmutableArray<SyntaxToken> Tokens { get; } = tokens;
}