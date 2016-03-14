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

var ViolationDate = "2014-10-26T00:00:00+06:00";

var match = System.Text.RegularExpressions.Regex
	.Match(ViolationDate, @"(?'Z'Z$)|(?'local'[\+\-]\d{1,2}:\d{1,2}$)");

match.Dump();

if (match.Success)
{
	if (match.Groups["Z"].Value != "")
		ViolationDate = DateTime
			.ParseExact(ViolationDate, "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture)
			.ToUniversalTime()//'Z' for UTC (Не зорро к сожалению) поэтому конвертим время в гринвич
			.ToString("dd.MM.yyyy");
	else if (match.Groups["local"].Value != "")
		ViolationDate = DateTime
			.ParseExact(ViolationDate, "yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture)
			
			.ToString();
	else
	{
		"Неправильный формат строки даты".Dump();
	}
}
else
{
	"Неправильный формат строки даты".Dump();
}

ViolationDate.Dump("Rez");