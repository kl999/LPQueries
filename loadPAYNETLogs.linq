<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var di = new DirectoryInfo(@"C:\sp\paynet logs");
	
	foreach(var file in di
						  .GetFiles()
						  .OrderBy(i =>
		{
			var m = Regex.Match(i.Name,
				@"\d{4}-\d{2}-\d{2}-\d{2}");
			if(m.Success)
				return DateTime.ParseExact(
					m.Value,
					"yyyy-MM-dd-HH",
					System.Globalization.CultureInfo.InvariantCulture);
			else
				return(new DateTime(1,1,1));
		})
	)
	{
		new[]{ file }.SelectMany(i => transformLog(i))
		.Reverse()//.OrderByDescending(i => i.date)
		.Select(i =>
		{
			string xml = i.inf != null && Regex.IsMatch(i.inf, @"\<\?xml") ?
				Regex.Match(i.inf, @"\<\?xml.*?\>\<([\w :]+)\s?.*?\>.*\</(\1)\>").Value : "";
			
			return new 
			{
				entry = i,
				xml
			};
		})
		.Select(i =>
		{
			//i.Dump(); ("\n-------------\n\n").Dump();
			
			XmlDocument xml = new XmlDocument(); ;
			
			if(i.xml != "")
				xml.LoadXml(i.xml);
			
			return new
			{
				i.entry.date,
				i.entry.num1,
				i.entry.desc,
				i.entry.inf,
				xml,
				i.entry.path,
				i.entry.additionalInfo
			};
			
		})
		.OnDemand(file.Name).Dump();
	}
}

IEnumerable<Obj> transformLog(FileInfo file)
{
	//"Defered?".Dump();
	string[] lines = new StreamReader(file.OpenRead(),
		Encoding.GetEncoding("windows-1251")).ReadToEnd().Split('\n');
	
//	string[] lines = File.ReadAllLines(@"C:\sp\paynet logs\paynetlog",
//		Encoding.GetEncoding("windows-1251"));
	
	List<Obj> entries = new List<Obj>(new[] { new Obj() });
	
	for(int i = 0; i < lines.Length; i++)
	{
		var match = Regex.Match(lines[i],
			@"(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\."
			+ @"\d{4}).*\s[# |]\s(\d+)\s[# |]\s(\w+)\s[# |]\s.*?\s[# |]"
			+ @"\s([\w \.]+)\s[# |]\s.*\s[# |]\s(.*)");
		
		if(match.Success)
		{
			//match.Dump();
			
			entries.Add(new Obj()
			{
				date = DateTime.ParseExact(match.Groups[1].Value.Trim(),
					"yyyy-MM-dd HH:mm:ss.ffff",
					System.Globalization.CultureInfo.InvariantCulture),
				
				num1 = Int32.Parse(match.Groups[2].Value.Trim()),
				
				desc = match.Groups[3].Value.Trim(),
				
				path = match.Groups[4].Value.Trim(),
				
				inf = match.Groups[5].Value.Trim()
			});
		}
		else
		{
			entries.Last().additionalInfo += lines[i] + "\n";
		}
	}
	
	return entries.AsEnumerable();
}

class Obj
{
	public DateTime date;
	
	public int num1;
	
	public string desc;
	
	public string path;
	
	public string inf;
	
	public string additionalInfo = "";
}