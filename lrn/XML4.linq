<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var rand = new Random();

XElement e = new XElement(
	"root",
	new byte[9999]
		.Select((i, ind) => new XElement("El" + (ind + 1), rand.Next(9) + 1))
);

var sw = new System.Diagnostics.Stopwatch();

XNode ch = e.FirstNode;
sw.Restart();
for(;;)
{
	if(ch == null) break;
	
	ch = ch.NextNode;
}
sw.Stop();
sw.Dump("NextNode");

ch = e.LastNode;
sw.Restart();
for(;;)
{
	if(ch == null) break;
	
	ch = ch.PreviousNode;
}
sw.Stop();
sw.Dump("PreviousNode");

e.Dump();

e.RemoveAll();

e.Value = "50";
e.Add(new XElement("Z"));
//e.Element("Z").SetValue(null); <- err
e.Element("Z").SetValue(DateTime.Now);

((DateTime?)e.Element("Z")).Dump();

e.ToString().Dump("Date");

e = XElement.Parse(@"<a><b><c><d/></c></b></a>");

var x = e.Descendants().First(i => i.Name == "d");

x.AncestorsAndSelf().Dump();

e.Element("b").Dump();

e.Element("b").ReplaceWith(new XElement("message", "Hello world!"));

e.SetElementValue("x", "Why?");

e.Element("x").Add(new XElement("Zed"));

e.Element("x").Element("Zed").SetAttributeValue("z", 32);

e.ToString().Dump();