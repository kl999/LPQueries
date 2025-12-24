<Query Kind="Statements">
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
</Query>

var str = System.Text.Json.JsonSerializer.Serialize(new A{ a = "asd", b = 2 }, new System.Text.Json.JsonSerializerOptions 
{
	ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
	WriteIndented = true
}).Dump();

JsonSerializer.Deserialize<A>(str).Dump();

var jn = JsonNode.Parse(str).Dump();

var jn2 = jn["a"].Dump();

jn["c"] = new JsonObject();
jn["c"].AsObject().Add(new KeyValuePair<string, JsonNode>("d", new JsonArray()));
jn["c"]["d"].AsArray().Add("f");

jn.Dump("Add arr");

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

var b = new B
{
	Name = "bsd",
	Number = 2194,
};
var c = new C
{
	TheB = b,
	Bs = new(){ b, b, b },
};

JsonSerializer.Serialize(c, new JsonSerializerOptions()
{
    ReferenceHandler = ReferenceHandler.Preserve,
    WriteIndented = true
}).Dump();

class A
{
	public string a { get; set; }
	public int b { get; set; }
}

public class C
{
	public List<B> Bs { get; set; } = new();
	
	public B TheB { get; set; }
}

public class B
{
	public string Name { get; set; }
	public int Number { get; set; }
}
