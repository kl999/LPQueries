<Query Kind="Statements">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

"This is XML".Dump();

string str =
@"<root>
	<sub>Hello!</sub>
</root>";
XElement el = XElement.Parse(str);
el.ToString().Dump("1");

string str2 =
@"<rootTwo>
	<sub>Hello!</sub>
</rootTwo>";
XElement el2 = XElement.Parse(str2);
el2.ToString().Dump("2");

str =
@"<root>
	<sub hasAnythng = ""yes"" itIsHello = ""true"">Hello!</sub>
	<sub hasAnythng
		= ""yes"">All</sub>
	<nub>Nubs</nub>
	<sub hasAnythng = ""no""/>
	<sub hasAnythng = ""yes"">
		<deeper>thmth</deeper>
	</sub>
	asd
</root>";
el = XElement.Parse(str);

el.ToString().Dump();

el.Value.Dump("Root val");
el
.Elements("sub")
.Select(elmt =>
	elmt.Value
	+ " : " + String.Join(
		", ",
		elmt.Attributes().Select(i => i.Name + " = " + i.Value)
		)
	)
.Dump();

el = XElement.Parse(@"
<nums>
  <num>1</num>
  <num>5</num>
  <num>11</num>
</nums>
");

var sum = 0;
foreach(var numEl in el.Elements("num"))
    sum += (int)numEl;

sum.Dump("Explicit conversion");

el = XElement.Parse(
@"<a txt=""1&#10;2""/>");

el.Attribute("txt").Value.Dump("New line in attribute");
