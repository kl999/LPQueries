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
	var nums = getNums();
	
	nums
	.GroupBy(i => i.date)
	//.Dump("rez")
	;
	
	nums
	.OrderByDescending(i => i.date)
	.GroupBy(i => i.date)
	.Select(grp =>
	{
		return new
		{
			key = grp.Key,
			vals = grp.OrderByDescending(i => i.from).Select(i=>
			{
				return new
				{
					i.number,
					i.from,
					//i.to,
					duration = i.to.TotalSeconds - i.from.TotalSeconds
				};
			}).ToArray()
		};
	})
	.Dump();
	
	/*foreach(var num in nums)
	{
		num
		.ToString()
		.Dump()
		;
	}*/
}

List<Number> getNums()
{
	string[] loaded = File.ReadAllLines(
		//@"C:\Users\Psamarce\Desktop\vidPltReg\log.txt"
		@"D:\Документы\VideoPlateRegistration\VideoPlateRecognition\bin\Debug\log.txt"
		);
	
	//loaded.Dump();
	
	DateTime fragDT = new DateTime(2000, 1, 1);
	
	List<Number> nums = new List<Number>();
	
	foreach(string tstr in loaded)
	{
		Match m;
		
		m = Regex.Match(tstr, @"\d+\s\w+\s\d{4,}г\.");
		
		if(m.Success)
			fragDT = DateTime.Parse(tstr);
		
		m = Regex.Match(tstr, @"\{(.*)\}\tfrom\s<(.*?)>\sto\s<(.*?)>")
		//.Dump()
		;
		
		if(m.Success)
		{
			nums.Add(new Number()
			{
				number = m.Groups[1].Value,
				date = fragDT.Date,
				from = TimeSpan.Parse(m.Groups[2].Value),
				to = TimeSpan.Parse(m.Groups[3].Value)
			});
		}
	}
	
	//fragDT.Dump();
	
	//nums.Dump();
	
	return nums;
}

class Number
{
	public string number;
	
	public DateTime date;
	
	public TimeSpan from;
	
	public TimeSpan to;
	
	public override string ToString()
	{
		return number + " " + date + " " + from + " - " + to;
	}
}