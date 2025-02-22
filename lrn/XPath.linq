<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var doc = new XmlDocument();

doc.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<customers>
<account><id>1</id><val text=""asd""/></account>
<customer id=""123"" status=""archived"">
<firstname>Jim</firstname>
<lastname>Bo</lastname>
</customer>
<customer>
<firstname>Thomas</firstname>
<lastname>Jefferson</lastname>
</customer>
</customers>");

doc.SelectNodes(@"customers/account/*[not(@*)]").Dump("Here");

doc.SelectNodes ("//firstname").Dump("//");

doc.SelectNodes ("customers/customer/firstname/../*").Dump("..");

doc.SelectNodes ("customers/customer/*").Dump("*");

doc.SelectNodes ("customers/customer[@id=\"123\"]").Dump("[]");

doc.SelectNodes ("customers/customer[@id=\"123\"]/lastname").Dump();

doc.SelectSingleNode ("customers/customer/@id").Dump("@");

doc.SelectNodes ("customers/customer/firstname|customers/customer/lastname").Dump("|");

doc.SelectNodes ("customers/customer/@*").Dump("/* && [*]");

doc.SelectNodes ("customers/customer[@*]").Dump();

doc.SelectNodes ("customers/customer[last()]").Dump("last()");

doc.SelectNodes ("customers/customer[position() = 1]").Dump("position()");

doc.SelectNodes ("customers/customer[1]").Dump("[1]");

doc.SelectNodes ("customers/customer[@id=\"123\" and @status=\"archived\"]").Dump("AND");

XPathNavigator nav = doc.CreateNavigator();

foreach (XPathNavigator navC in nav.Select ("customers/customer/lastname"))
{
    navC.Value.Dump("nav");
}

var el = XElement.Parse(
@"<root>
  <sub a=""2"">two<sub>one</sub></sub>
  <sub a=""1"">one</sub>
  <sub>1</sub>
</root>");

el.Element("sub").SetAttributeValue("b", 35);//.AddAfterSelf(new System.Xml.Linq.XComment(""));
el.Element("sub").SetAttributeValue("b", "ZLO");

var temps = "";

Console.WriteLine(el.ToString());

Console.WriteLine();

IEnumerable<System.Xml.Linq.XContainer> temp = el.XPathSelectElements("sub[@a!=\"1\"]".Dump("---"));

foreach (var sel in temp)
    Console.WriteLine(sel);

IEnumerable<object> atrs = (IEnumerable<object>)el.XPathEvaluate("sub/@*".Dump("---"));

foreach(var atr in atrs)
    Console.WriteLine(atr as XAttribute);

atrs = (IEnumerable<object>)el.XPathEvaluate("sub[.=\"one\"]".Dump("---"));//"sub[../sub=\"one\"]");

foreach (var atr in atrs)
    Console.WriteLine(atr as XElement);

atrs = (IEnumerable<object>)el.XPathEvaluate("//@*[.=\"1\"]|*[.=\"1\"]");

temps = "";
foreach (var atr in atrs)
{
    temps += atr.ToString() + "\n";
}

temps.Dump("all 1s");

el = XElement.Parse(@"<root xmlns=""zns"">
  <sub a=""2"">two<sub>one</sub></sub>
  <sub a=""1"">one</sub>
  <sub>1</sub>
</root>");

var nsm = new XmlNamespaceManager(new NameTable());
nsm.AddNamespace("z", "zns");

el.XPathSelectElement("z:sub[@a!=\"1\"]", nsm).Dump("Namespaces");

el = XElement.Parse(@"<root>
  <el>
  	<a>1</a>
	<b>asd</b>
  </el>
  <el>
  	<a>2</a>
	<b>zxc</b>
  </el>
</root>");

el.XPathSelectElement(@"el[a = ""2""]/b").Dump("Search by el");
