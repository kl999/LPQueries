<Query Kind="Program">
  <Connection>
    <ID>b2aac786-6e24-43fc-aff9-4fa7b0f86818</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAB0aBac5XR15KW7AtZYYwGgAAAAAASAAACgAAAAEAAAAKutYqlP5CwXtVP0zaEla6JIAAAA0J+yYZ1aGj/rwGX2/HtUh4GOUFcLsH565L6NJ/0EDhoCVoGdUSAyLAgDZEutxqdAnj6Tq77ffFmOsdgtWxA7tlIk8XJ/6LOxFAAAABs0ugKbcjM3dDHhA1L9qCERMUUb</CustomCxString>
    <Server>192.168.0.200</Server>
    <Database>pir</Database>
    <UserName>pirro</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAL3HHybTAXUyevAVK/sFNrgAAAAACAAAAAAADZgAAwAAAABAAAAAAZo7tSVA6XHKSsWEOow6FAAAAAASAAACgAAAAEAAAAIj/YEY+5XhgXBjLXIFL8uQIAAAAzbd7I1B/A2AUAAAAShnQq8Gg1v9jqiQFtenEAHalhKM=</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DisplayName>To PIR (read only)</DisplayName>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
      <ExtraCxOptions>CharSet=utf8;</ExtraCxOptions>
    </DriverData>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//brainz
	var dt = DateTime.Now;
	
	Random rand = new Random(dt.Hour + dt.Millisecond);
	
	List<rNum> br = new List<rNum>();
	
	for(int i = 0; i < 30; i++)
	{
		br.Add(new rNum(rand.Next(10)));
	}
	
	br.Dump("Start");
	for(int brk = 0; brk < 100000; brk++)
	{
		//br.Dump();
		
		string input = 
			rand.Next(2) == 0 ? "7" : "9";
			//Console.ReadLine();
		
		if(input == "exit")
		{
			break;
		}
		
		int num = Int32.Parse(input);
		
		int[] a = new int[3];
		
		a = a.Select(i => rand.Next(br.Count)).ToArray();
		
		int guess = a.Select(i => br[i].num).Sum() / 3;
		
		int abs = Math.Abs(num - guess);
		
		if(abs == 0)
		{
			a.Select(i => {br[i].bad--; return 0;}).Sum();
		}
		else if(abs < 3)
		{
			
		}
		else if(abs < 5)
		{
			a.Select(i => {br[i].bad++; return 0;}).Sum();
		}
		else
		{
			a.Select(i => {br[i].bad += 2; return 0;}).Sum();
		}
		
		(brk + ":Number was " + num + " | " + guess + " was the guess").Dump();
		
		foreach(rNum obj in br)
		{
			if(obj.bad > 9)
			{
				br.Remove(obj);
				
				br.Add(new rNum(rand.Next(10)));
				
				break;
			}
		}
	}
	
	br.Dump("End");
	
	br
	.GroupBy(i => i.num)
	.Select(i => new{ i.Key, ct = i.Count() })
	.OrderByDescending(i => i.ct)
	.Dump();
}

class rNum
{
	public int num;
	
	public int bad = 0;
	
	public rNum(int _num)
	{
		num = _num;
	}
}