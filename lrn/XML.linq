<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
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