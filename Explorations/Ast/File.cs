namespace Ast;

using RhoMicro.CodeAnalysis;

[UnionType(typeof(Unit))]
[UnionType(typeof(String))]
readonly partial struct File
{
    public static File None { get; } = Unit.Instance;
}