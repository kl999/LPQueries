<Query Kind="Statements">
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string dir = @"C:\PayNetSVN\ImExHandlers\configs\Спецмашин",
	tabName = "OEM",
	colName = "ABN_CODE";

DataTable dt = null;

dt = my.getDbf(dir, tabName);

dt.AsEnumerable().OnDemand("Raw").Dump();

var grpd = dt
.AsEnumerable()
.Select(orow =>
{
	var row = (DataRow)orow;
	
	return new
	{
		dup = row[colName],
		row
	};
})
.GroupBy(i => i.dup)
.ToList();

grpd
.Where(i => i.Count() > 1)
.OrderByDescending(i => i.Count())
//.Where(i => i.Where(o => (string)o.row["KOD"] == "20").Count() > 1)
.OnDemand("Duplicates - " + grpd.Where(i => i.Count() > 1).Count())
.Dump();

grpd
.Where(i => i.First().dup == null || ((string)i.First().dup) == "")
.OnDemand("Empty - "
	+ grpd.Where(i => i.First().dup == null || ((string)i.First().dup) == "").Count()
)
.Dump();

/*grpd
.Where(i => i.Where(o => Regex.IsMatch((string)o.dup, "0929002.*")).Count() > 0)
.Dump();*/