<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var cfg = new ConfigurationManager();
	
	cfg["a"] = "b";
	var cCfg = cfg.GetSection("c");
	cCfg["d"] = "e";
	
	cfg.Dump();
	
	var jsonCfg = ConfigAsJson(cfg);
	jsonCfg.ToString().Dump();
}

JsonObject ConfigAsJson(IConfiguration cfg)
{
	var result = new JsonObject();
	
	foreach (var section in cfg.GetChildren())
	{
		if (section.GetChildren().Count() > 0)
			result[section.Key] = ConfigAsJson(section);
		else
			result[section.Key] = section.Value;
	}
	
	return result;
}
