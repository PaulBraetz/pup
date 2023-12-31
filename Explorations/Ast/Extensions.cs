namespace Ast;

using System.Collections.Immutable;

static class Extensions
{
    public static StringSlice Slice(this String s, Int32 start, Int32 length) => new(s, start, length);
    public static IOutputBuilder Append(this IOutputBuilder builder, SyntaxNode node)
    {
        node.AppendToOutput(builder);
        return builder;
    }
    public static IOutputBuilder Append(this IOutputBuilder builder, SyntaxToken token) =>
        builder.Append(token.Text);
    public static IOutputBuilder Append(this IOutputBuilder builder, SyntaxTokenList tokens) =>
        tokens.Tokens.Aggregate(builder, Append);
    public static IOutputBuilder Append<T>(this IOutputBuilder builder, ImmutableArray<T> nodes)
        where T : SyntaxNode =>
        nodes.Aggregate(builder, Append);
    public static IOutputBuilder Append(this IOutputBuilder builder, Maybe<SyntaxToken> maybeToken) =>
        maybeToken.Bind(t => builder.Append(t.Text), builder);
    public static IOutputBuilder Append(this IOutputBuilder builder, Maybe<SyntaxTokenText> maybeTokenText) =>
        maybeTokenText.Bind(builder.Append, builder);
}