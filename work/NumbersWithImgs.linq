<Query Kind="Statements">
  <Connection>
    <ID>6286e2da-88e1-4458-81eb-d9ee653dc7e6</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAhcs/CVWJAUqCcoBOjqPB/AAAAAACAAAAAAADZgAAwAAAABAAAACEflWspbRo4Sjf0XoxylfVAAAAAASAAACgAAAAEAAAADGOlBQyOL/Jy+FyHa5cbCw4AAAATU39f1Q3upI3mvMZg0fwWDUtWc8M7Mx6VPhiIA6tmDe+iymOYJs8bKUM9opC/f3oQgW/2RTRIDgUAAAAdSA7E+vclfKMwrScIQUkuAhtB9M=</CustomCxString>
    <Server>127.0.0.1</Server>
    <UserName>root</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAhcs/CVWJAUqCcoBOjqPB/AAAAAACAAAAAAADZgAAwAAAABAAAACCzoibmp3f4BVJxyrcPv96AAAAAASAAACgAAAAEAAAABk6FAsO+fIXN/wW3aunZdoIAAAAXOfbF0TPiOEUAAAAcGIH3Q7kEx7bGDVybTb0u1moLmU=</Password>
    <DisplayName>Local MySQL</DisplayName>
    <Database>plReg</Database>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
    </DriverData>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Numbers.Count().Dump("Count");

var nq = Numbers
.OrderBy(i => i.From)
.Reverse();

//nq
//.Take(1000)
//.GroupBy(i => i.Number)
//.Where(i => i.Count() > 1)
//.Dump("Group test");

nq
.Take(5)
.AsEnumerable()

.Select(i =>
{
	byte[] buf = ((byte[])i.NumImg);
	
	Bitmap NumImg = new Bitmap(new MemoryStream(buf));
	
	buf = ((byte[])i.PrevImg);
	
	Bitmap PrevImg = new Bitmap(new MemoryStream(buf));
	
	return new { i.Number, i.From, i.To, NumImg, PrevImg };
}).OnDemand("5 last").Dump();

"\nShow numbers for this day:".Dump();
foreach(var hr in
	nq
	.Where(i => i.From > DateTime.Now.Date)
	.AsEnumerable()
	.GroupBy(i => i.From.GetValueOrDefault().Hour)
)
{
	hr
	.Select(i =>
	{
		byte[] buf = ((byte[])i.NumImg);
		
		Bitmap NumImg = new Bitmap(new MemoryStream(buf));
		
		buf = ((byte[])i.PrevImg);
		
		Bitmap PrevImg = new Bitmap(new MemoryStream(buf));
		
		return new { i.Number, i.From, i.To, NumImg, PrevImg };
	})
	.OnDemand(hr.Key + "h Ct: " + hr.Count()).Dump();
}

@"

--------------------------

".Dump();

nq
.AsEnumerable()
.GroupBy(i => i.Number)
.Select(i =>
{
	List<DateTime> dates = new List<DateTime>();
	
	return i.Where(o =>
	{
		if(!dates.Any(o2 => Math.Abs((o2 - (DateTime)o.From).TotalSeconds) < 300))
		{
			dates.Add((DateTime)o.From);
			
			return true;
		}
		else
			return false;
	}).ToArray();
})
.Where(i => i.Count() > 1)
.Select(o =>
	o
	.Select(i =>
	{
		byte[] buf = ((byte[])i.NumImg);
		
		Bitmap NumImg = new Bitmap(new MemoryStream(buf));
		
		buf = ((byte[])i.PrevImg);
		
		Bitmap PrevImg = new Bitmap(new MemoryStream(buf));
		
		return new { i.Number, i.From, i.To, NumImg, PrevImg };
	})
)
.OnDemand("More than once").Dump();

"\n".Dump();

nq
.Select(i => new{ i.Id, i.Number, Time = i.From })
.AsEnumerable()
.GroupBy(i => ((DateTime)i.Time).Date)
.Select(i =>
{
	int totalCount = i.Count();
	int maskedCount = i.Where(o => o.Number.Contains("(mask)")).Count();
	
	return new{
		Time = i.Key,
		TotalCount = totalCount,
		MaskedProc = (double)((int)(((double)maskedCount / totalCount) * 10000)) / 100 };
})
.OnDemand("Masks in days")
.Dump();

"\n\n".Dump();

DateTime day = new DateTime(1, 1, 1, 1, 1, 1);
day = DateTime.Parse(Console.ReadLine() + " 00:00:00 AM");
bool getInp = true;
nq
.AsEnumerable()
.Where(i =>
{
    return i.From >= day && i.From < day.AddDays(1);
})
.Select(i =>
{
    byte[] buf = ((byte[])i.NumImg);
    
    Bitmap NumImg = new Bitmap(new MemoryStream(buf));
    
    buf = ((byte[])i.PrevImg);
    
    Bitmap PrevImg = new Bitmap(new MemoryStream(buf));
    
    return new { i.Number, i.From, i.To, NumImg, PrevImg };
})
.OnDemand("Numbers for some date " + day.ToString())
.Dump();