namespace Ast;
using System.Text;
using System.Threading;

sealed class OutpuBuilder : IOutputBuilder
{
    private readonly StringBuilder _builder = new();
    public IOutputBuilder Append(SyntaxTokenText text)
    {
        text.Switch(
        s => _builder.Append(s.AsSpan()),
        c => _builder.Append(c),
        s => _builder.Append(s));
        return this;
    }

    public String Build(CancellationToken cancellationToken) => _builder.ToString();
}
