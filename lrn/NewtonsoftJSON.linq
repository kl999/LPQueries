<Query Kind="Program">
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Bson</Namespace>
  <Namespace>Newtonsoft.Json.Converters</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Schema</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var jstr = "";
    
    /*Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
    serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
    serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
    serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
    
    using (var ms = new MemoryStream())
    using (var sw = new StreamWriter(ms))
    using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
    {
        serializer.Serialize(writer, new A(){ a = new B() }, typeof(A));
        
        sw.Flush();
        
        jstr = Encoding.UTF8.GetString(ms.ToArray());
        
        jstr.Dump("rez");
    }*/
    
    jstr = JsonConvert.SerializeObject(new A(){ a = new B(), d = TstEnum.Tmth }, new Newtonsoft.Json.JsonSerializerSettings 
    { 
        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        Formatting = Newtonsoft.Json.Formatting.Indented,
    });
    
    jstr.Dump();
    
    A  a = Newtonsoft.Json.JsonConvert.DeserializeObject<A>(jstr, new Newtonsoft.Json.JsonSerializerSettings 
    { 
        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
    });
    
    a.Dump();
    
    jstr = @"
{
  'c': 'Rty',
  'a': {
    '$type': 'UserQuery+B, " + Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase) + @"',
    'c': 'Qwe',
    'd': false,
    'e': 'Unknown',
    'dic': {
        'some': 5,
        'word': 10
    }
  },
  'd': 1
}";

jstr.Dump();
    
    a = Newtonsoft.Json.JsonConvert.DeserializeObject<A>(jstr, new Newtonsoft.Json.JsonSerializerSettings 
    { 
        TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
        NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
    });
    
    a.Dump();
    
    var c = new C{ a = 2, b = new object[]{ new D{ z = 5, x = "z" }, new D{ z = 5, x = "z" }, new{ q = 3 } } };
    var json = JsonConvert.SerializeObject(c).Dump();
    
    var o = JsonConvert.DeserializeObject<C>(json).Dump();
    
    o.b.Select(i => (i as JObject).ToObject<D>()).Dump();
}

class A : IA
{
    public IA a;
    private int b = 7;
    public string c {get;set;} = "Hello";
    
    public TstEnum d = TstEnum.Hello | TstEnum.World;
}

enum TstEnum
{
    Hello = 1,
    World = 2,
    
    Programm = Hello | World,
    Tmth = 352719
}

interface IA
{
    string c {get; set;}
}

class B : IA
{
    public string c { get;set; } = "World";
    public bool d = false;
    public Dictionary<string, int> dic = new Dictionary<string, int>
    {
        ["Hi"] = 1,
        ["World"] = 17,
    };
}

class C
{
    public int a;
    public object[] b;
}

class D
{
    public int z;
    public string x;
}