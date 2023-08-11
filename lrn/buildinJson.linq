<Query Kind="Statements">
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
</Query>

var str = JsonSerializer.Serialize(new A{ a = "asd", b = 2 }, new JsonSerializerOptions 
{
	WriteIndented = true
}).Dump();

JsonSerializer.Deserialize<A>(str).Dump();

var jn = JsonNode.Parse(str).Dump();

var jn2 = jn["a"].Dump();

((string)jn2).Dump();
jn2.GetValue<string>().Dump();

var jo = new JsonObject
{
	["inner"] = new JsonObject
	{
		["a"] = "b",
		["b"] = 1,
	}
}
.Dump();

jo["two"] = 2;

jo.Dump();

jo["inner"].Deserialize<A>().Dump();

jo.Remove("two");

jo.Dump();

class A
{
	public string a { get; set; }
	public int b { get; set; }
}