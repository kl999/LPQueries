<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Convert.ToDecimal("6 543,05", "### 000.00")
//Decimal.Parse("6 807,21")
Decimal.Parse(
Encoding.GetEncoding(1251).GetString(new byte[]
	{
		0x36,
		0xA0,
		0x38,
		0x30,
		0x37,
		0x2C,
		0x32,
		0x31
	}).Dump(),
System.Globalization.CultureInfo.CreateSpecificCulture("ru-RU")).Dump();