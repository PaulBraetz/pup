namespace Explorations.GreenThreads;

[UnionType(typeof(Exception), Alias = "Error")]
[UnionType(nameof(T), Alias = "Result")]
[UnionType(typeof(Unit), Alias = "NonTerminated")]
[UnionTypeSettings(Layout = LayoutSetting.Auto)]
readonly partial struct GreenThreadResult<T>
{
    public Boolean IsTerminated => IsError || IsResult;
    public static readonly GreenThreadResult<T> NonTerminated = CreateFromNonTerminated(new());
}
