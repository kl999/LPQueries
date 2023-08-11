<Query Kind="Statements">
  <Namespace>System.Threading.Channels</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var dc = new DumpContainer ("...").Dump("To read");

var channel = Channel.CreateUnbounded<int>(new UnboundedChannelOptions
{
    SingleWriter = true,
});

var b = Task.Run(async () =>
{
    var writer = channel.Writer;

    for (int i = 0; i < 100; i++)
    {
        await Task.Delay(250);

        writer.TryWrite(i);
    }

    writer.Complete();
});

for (int x = 0; x < 2; x++)
{
    b = Task.Run(async () =>
    {
        var reader = channel.Reader;

        for (; await reader.WaitToReadAsync(); )
        {
            await Task.Delay(200 + Random.Shared.Next(1000));

            var rez = await reader.ReadAsync();

            Console.WriteLine(rez);
        }
    });
}

b = Task.Run(async () =>
{
    var reader = channel.Reader;

    for (; await reader.WaitToReadAsync(); )
    {
		dc.Content = reader.Count;
    }
});

await channel.Reader.Completion;

b.Wait();
Console.WriteLine("End");
