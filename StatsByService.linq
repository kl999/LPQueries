<Query Kind="Statements">
  <Connection>
    <ID>272431ed-01c6-4bb4-ac55-985d26c201f4</ID>
    <Persist>true</Persist>
    <Server>db-paynet</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>PaynetDB</Database>
    <UserName>PaynetDBOwner</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAD3LmAGy+IkOR/3qrx+HoeQAAAAACAAAAAAADZgAAwAAAABAAAABwJob4wHhJ0FrmTrlQyzE0AAAAAASAAACgAAAAEAAAANTm1Lg7+5jWttn1vDbAlk4QAAAAyOEb7K/LTdFm+Pal30glnRQAAAA7Rs2x/65mA3EGU17VAcgeeJysMw==</Password>
    <NoPluralization>true</NoPluralization>
    <IsProduction>true</IsProduction>
  </Connection>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
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


var svcList = new List<int>(new[] { 724 });

var raw = Tbl_RQ
.Where(i =>
    i.VchRequestType == "payment"
    && svcList.Contains(i.IntServiceId)
    && (i.IntProvResultCode == 0)
    && i.DtProvTimestamp >= DateTime.Parse("1.10.15")
)
.ToArray();

raw
.GroupBy(i => i.DtProvTimestamp?.Date)//.Dump();
.Select(i => new{ Date = i.Key?.ToString("dd.MM.yyyy"), Count = i.Count() })
.Dump("Payments By Days");

raw
.GroupBy(i => i.DtProvTimestamp?.Hour)//.Dump();
.Select(i => new{ Hour = i.Key?.ToString(), Count = i.Count() })
.OrderBy(i =>
{
    int tmp = -1;
    Int32.TryParse(i.Hour, out tmp);
    return tmp;
})
.Dump("Payments By Hours");