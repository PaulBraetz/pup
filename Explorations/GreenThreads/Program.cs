using System.Diagnostics;

var threads = Enumerable.Range(0, 1000)
    .Select(i => GreenThread<Unit>.Run(c =>
    {
        waitAndPrint(c);
        return new Unit();
    }))
    .GroupBy(t => t.Context.Id % 64)
    .SelectMany(g => g.ToList());

Console.WriteLine("Joining");
var sw = new Stopwatch();
var ids = new HashSet<Int32>();
sw.Start();
foreach(var t in threads)
{
    t.Join();
    _ = ids.Add(t.Context.Id);
}

sw.Stop();
Console.WriteLine("Joined");
Console.WriteLine(sw.Elapsed.TotalMilliseconds);
Console.WriteLine($"ID count: {ids.Count}");

static void waitAndPrint(GreenThreadContext c)
{
    if(c.Cancellation.IsCancellationRequested)
    {
        Console.WriteLine($"T{c.Id} cancelled {DateTime.Now.Ticks}");
    } else
    {
        Thread.Sleep(1000);
        Console.WriteLine($"T{c.Id} done {DateTime.Now.Ticks}");
    }
}
