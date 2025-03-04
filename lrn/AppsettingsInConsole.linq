<Query Kind="Statements">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false)
				;

IConfiguration config = builder.Build();

config["asd"] = "123";

config.Dump();
