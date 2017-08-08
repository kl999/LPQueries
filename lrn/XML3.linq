<Query Kind="Statements" />

XElement config = XElement.Parse (
@"<configuration>
	<client enabled='true'>
		<timeout>30</timeout>
	</client>
	<pass regex='^(?=(.*\d){3,})(?=.*[A-Z])[\d\w]{5,8}$'/>
</configuration>");

foreach (XElement child in config.Elements())
	child.Name.Dump ("Child element name");

XElement client = config.Element ("client");

bool enabled = (bool) client.Attribute ("enabled");   // Read attribute
enabled.Dump ("enabled attribute");

client.Attribute ("enabled").SetValue (!enabled);     // Update attribute

int timeout = (int) client.Element ("timeout");       // Read element
timeout.Dump ("timeout element");

client.Element ("timeout").SetValue (timeout * 2);    // Update element

client.Add (new XElement ("retries", 3));    // Add new elememt

string pass = "asDfg153";
if(Regex.IsMatch(pass, (string)config.Element("pass").Attribute("regex")))
	config.Element("pass").Add(new XElement("word", pass));

config.Dump ("Updated DOM");

var el = XElement.Parse(@"
<asd><qwe>a</qwe>d</asd>
");

el.Dump();

el.Value.Dump("Val");

el.Element("qwe").Value.Dump("qwe");

foreach(var o in el.Nodes())
{
    o.GetType().Name.Dump();
    
    if(o is XText)
        o.Dump();
    if(o is XElement)
        (o as XElement).Value.Dump();
}

XNamespace ns = "http://www.my.ns/";
XNamespace emptyNs = "";

el = new XElement(ns + "Hello");
var wel = new XElement(emptyNs + "world");
el.Add(wel);
wel.SetAttributeValue(ns + "att", "Iamns");

el.Dump();