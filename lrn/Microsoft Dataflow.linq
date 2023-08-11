<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

var tb = new TransformBlock<int, int>(async i =>
{
    await Task.Delay(90);
    return i * 1;
});

var bcb = new BroadcastBlock<int>(null);

var ab = new ActionBlock<int>(async i =>
{
    await Task.Delay(100);
    Console.WriteLine(i);
    await Task.Delay(Random.Shared.Next(500));
});
var ab2 = new ActionBlock<int>(async i =>
{
    await Task.Delay(100);
    Console.WriteLine(i);
    await Task.Delay(Random.Shared.Next(500));
}, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 2 });

tb.LinkTo(bcb);

bcb.LinkTo(ab);
bcb.LinkTo(ab2);

for (int i = 0; i < 50; i++)
    tb.Post(i);

tb.MyDump();

bcb.MyDump();

ab.MyDump();
ab2.MyDump();

Task.WhenAll(ab.Completion, ab2.Completion).ContinueWith(t =>
{
	bcb.Complete();
	bcb.Receive();
});

var bb = new BatchBlock<int>(5);
var bb2 = new BatchBlock<int>(15);
var tb2 = new TransformBlock<IEnumerable<int>, int>(async i =>
{
    await Task.Delay(100 + Random.Shared.Next(300));
    Console.WriteLine(i.Sum());

    return i.Sum();
});

Enumerable.Range(1, 151).ToList().ForEach(i => bb.Post(i));

bb.LinkTo(tb2);
bb.Completion.ContinueWith(t => tb2.Complete());
tb2.LinkTo(bb2);
tb2.Completion.ContinueWith(t => bb2.Complete());

bb.Complete();

bb.MyDump();
tb2.MyDump();
bb2.MyDump();

var tb3 = new TransformBlock<int, int>(async i =>
{
    await Task.Delay(100);
    return i;
});

var ab3 = new ActionBlock<int>(async i =>
{
    await Task.Delay(100);
    Console.WriteLine(i);
    await Task.Delay(Random.Shared.Next(500));
}, new ExecutionDataflowBlockOptions { BoundedCapacity = 5 });

var ab4 = new ActionBlock<int>(async i =>
{
    await Task.Delay(100);
    Console.WriteLine(i);
    await Task.Delay(Random.Shared.Next(500));
}, new ExecutionDataflowBlockOptions { BoundedCapacity = 5 });

Enumerable.Range(1, 100).ToList().ForEach(i => tb3.Post(i));

tb3.LinkTo(ab3);
tb3.LinkTo(ab4);

tb3.MyDump();
ab3.MyDump();
ab4.MyDump();

//IDataflowBlockHelper.WaitAll();

Console.WriteLine("End!");

static class IDataflowBlockHelper
{
    static List<IDataflowBlock> blocks = new();

    public static void MyDump(this IDataflowBlock block)
    {
        blocks.Add(block);

        block.Dump();
    }

    public static void WaitAll()
    {
        foreach (var block in blocks)
        {
            block.Complete();

            block.ReadToEnd();

            block.Completion.Wait();
        }
    }

    private static void ReadToEnd(this IDataflowBlock block)
    {
        if (block.GetType().GetGenericTypeDefinition() == typeof(ISourceBlock<>))
        {
            for (; ; )
            {
                dynamic dblock = block;

                dblock.TryReceiveAll(out object _);

                if (block.Completion.IsCompleted) break;

                Thread.Sleep(50);
            }
        }
    }
}
