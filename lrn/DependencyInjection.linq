<Query Kind="Program">
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

async void Main()
{
	using IHost host = Host.CreateDefaultBuilder()
	    .ConfigureServices(services =>
	    {
	        services.AddTransient<IHello, Hello>();
	        services.AddScoped<IWorld, World>();
        	services.AddHostedService<BGSvc>();
        	services.AddHostedService<HostedSvc>();
	    }
	    )
	    .Build();

	var hello = host.Services.GetRequiredService<IHello>();

	Console.WriteLine(hello.GetStr());
	hello.GetStr();

	using (var scope = host.Services.CreateScope())
	{
	    var prov = scope.ServiceProvider;

	    var world = prov.GetRequiredService<IWorld>();

	    Console.WriteLine(world.GetStr());
	    Console.WriteLine(world.GetStr());
	    Console.WriteLine(world.GetStr());
	}

	Console.WriteLine("New system:");
	using (var scope = host.Services.CreateScope())
	{
	    var prov = scope.ServiceProvider;

	    var world = prov.GetRequiredService<IWorld>();

	    Console.WriteLine(world.GetStr());
	    Console.WriteLine(world.GetStr());
	}
	
	var tsk = Task.Run(async () => { await Task.Delay(5000); await host.StopAsync(); });

	await host.StartAsync();
}

interface IHello
{
    string GetStr();
}

class Hello : IHello
{
    public string GetStr()
    {
        return $"Hello!";
    }
}

interface IWorld
{
    string GetStr();
}

class World : IWorld
{
    public int ct;

    public string GetStr()
    {
        return $"world #{ct++}";
    }
}

class HostedSvc : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Started");

        await Task.Run(async () =>
        {
            for (; ; )
            {
                Console.WriteLine("...");

                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("...IsCancellationRequested!");
                    break;
                }

                try
                {
                    await Task.Delay(1000, cancellationToken);
                }
                catch (TaskCanceledException) { }
            }
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stoped");
        return Task.CompletedTask;
    }
}

class BGSvc : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		for (; ; )
        {
            Console.WriteLine("...");

            if (stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("...IsCancellationRequested!");
                break;
            }

            try
            {
                await Task.Delay(1000, stoppingToken);
            }
            catch (TaskCanceledException) { }
        }
	}
}
