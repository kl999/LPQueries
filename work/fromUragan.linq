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
	DateTime fromDate = DateTime.Now.Date.AddDays(-1);

	var query = TrafficUraganView
	//.Where(i => i.SysTime >= Int64.Parse(fromDate.ToString("yyyyMMddHHmmss")))
	.OrderBy(i => i.SysTime)
	.Select(i => 
	new
	{
		Time = toNormDT(i.SysTime.ToString()),
		i.Plate,
		i.Country,
		i.CamDesc,
		i.CrdDesc,
		i.Speed,
		CarTime = toNormDT(i.CarTime.ToString())
	})
	.AsEnumerable()
	.Distinct()
	.ToList()
	//.Dump()
	;
	
	if(query.Count == 0) { "No elements!".Dump(); return; }
	
	("From <" + query.Min(i => i.Time)
	+ "> to <" + query.Max(i => i.Time) + ">").Dump("Dates");
	
	int ct = query.Count();
	String.Format("{0:N0}", ct).Dump("Rows");
	
	query
	.GroupBy(i => i.Country)
	.Select(i => new{Country = i.Key, Count = i.Count()})
	.Dump("Plates by country");
	
	/*query
	.Select(i => new
	{
		i.Time,
		i.CarTime,
		Difference = Math.Abs((i.CarTime - i.Time).TotalSeconds)
	})
	.OrderByDescending(i => i.Difference)
	.Dump();*/
	
	var q2 = query
	.Where(i => !i.Plate.Contains('*'))
	.GroupBy(i => i.Plate)
	//.Where(i => i.Count() > 1)
	.Select(i =>
	{
		int? mSpd = i.Max(j => j.Speed);
		
		mSpd = mSpd != 0 ? mSpd : null;
		
		return new
		{
			Ctry = i.First().Country,
			Plate = i.Key,
			ct = i.Count(),
			MaxSpeed = mSpd
		};
	})
	//.OrderByDescending(i => i.ct)
	.ToList();
	
	q2
	//.Where(i => i.Ctry != "KAZ" && i.Ctry != "")
	.GroupBy(i => i.Ctry)
	.Select(i =>i.OrderByDescending(j => j.ct).Take(20))
	.ToList().Dump("Twenty most spotted by country");
	
	q2
	.Where(i => i.MaxSpeed > 60)
	.OrderByDescending(i => i.MaxSpeed)
	.Take(20)
	.Dump("First twenty fast");
	
	/*query
	.GroupBy(i => i.Country)
	.Select(i => new{i.Key, plates = i.GroupBy(j => j.Plate)})
	.Dump();*/
	
	/*query
	.Where(i => i.Plate.Contains('*'))
	.GroupBy(i => i.Plate)
	.Select(i => new{i.Key, ct = i.Count()})
	.OrderByDescending(i => i.ct)
	.Dump();*/
	
	var assumeQry = query
	//.Where(i => i.Time > DateTime.Now.Date.AddDays(-1))
	.ToList();
	
	var badPlts = assumeQry
		.Where(i => i.Plate.Contains('*'))
		.Select(i => i.Plate)
		.ToList();
		
	var goodPlts = 
		/*assumeQry
			.Where(i => !i.Plate.Contains('*'))
			.Select(i => i.Plate)
			.ToList();*/
		q2
			.Take(20)
			.Select(i => i.Plate)
			.ToList();
	
	(
		from plate in goodPlts
		select 
		new
		{
			plate,
			Assume = badPlts
				.Where(i => anyStar(plate, i))
				.ToList()
		}
	)
	//.Where(i => i.Assume.Count() > 0)
	.Dump("Additional most spotted assumption");
	
	query
	.GroupBy(i => i.CrdDesc)
	.Select(i =>
	new
	{
		i.Key,
		dirs = i.GroupBy(j => j.CamDesc)
		.Select(k =>
		{
			double? avgS = k.Where(j => j.Speed != 0).Average(j => j.Speed);
			
			avgS = avgS == null ? avgS : Math.Round((double)avgS);
			
			int ggct = k.Count();
			
			return new
			{
				k.Key,
				transportCt = ggct,
				avgSpd = avgS,
				maxSpd = k.Where(j => j.Speed != 0).Max(j => j.Speed),
				noSpeed = k.Where(j => j.Speed == 0).Count(),
				badPlate = k.Where(j => j.Plate.Contains('*')).Count()
			};
		})
	})
	.Dump("Crossroads");
	
	query
	.Select(i => i.CamDesc)
	.Concat(query.Select(i => i.CrdDesc))
	.Concat(query.Select(i => i.Country))
	.Distinct()
	//.Count()
	.Dump("different strings");
	
	badPlts
	.GroupBy(i => new String('*', Regex.Matches(i, @"\*").Count))
	.Select(i => new{ stars = i.Key, count = i.Count() })
	.Dump("Starred");
	
	query
	.GroupBy(i =>
	new DateTime(
		i.Time.Year
		, i.Time.Month
		, i.Time.Day
		, i.Time.Hour
		, 0
		, 0)
	)
	.Select(sqry =>
	{
		int sct = sqry.Count();
		
		int sNoSpd = sqry.Where(i => i.Speed == 0).Count();
	
		string NoSpeed = (String.Format("{0:N0}", sNoSpd)
			+ String.Format(" - {0:0}%", (double)sNoSpd / sct * 100));
		
		int sBadPlt = sqry.Where(i => i.Plate.Contains('*')).Count();
		
		string BadPlate = (String.Format("{0:N0}", sBadPlt)
			+ String.Format(" - {0:0}%", (double)sBadPlt / sct * 100));
	
		return new
		{
			Date = sqry.Key,
			Count = String.Format("{0:N0}", sct),
			NoSpeed,
			BadPlate
		};
	})
	.OrderByDescending(i => i.Date)
	.Take(48)
	.Dump();
	
	/*int noSpd = query.Where(i => i.Speed == 0).Count();
	
	(String.Format("{0:N0}", noSpd)
	+ String.Format(" - {0:0}%", (double)noSpd / ct * 100)).Dump("No speed");
	
	int badPlt = badPlts.Count();
	
	int goodPlt = ct - badPlt;
	
	(String.Format("{0:N0}", badPlt)
	+ String.Format(" - {0:0}%", (double)badPlt / ct * 100)).Dump("Bad plate");*/
	
	query.Where(i => i.Plate == "B467PWN").Dump();
}

DateTime toNormDT(string str)
{
	int[] tarr = new int[str.Length];
	
	for(int i = 0; i < str.Length; i++)
	{
		tarr[i] = Int32.Parse(str[i].ToString());
	}

	/*int y = Int32.Parse(new string(str.Take(4).ToArray()));
	
	int M = Int32.Parse(new string(str.Skip(4).Take(2).ToArray()));
	
	int d = Int32.Parse(new string(str.Skip(6).Take(2).ToArray()));
	
	int h = Int32.Parse(new string(str.Skip(8).Take(2).ToArray()));
	
	int m = Int32.Parse(new string(str.Skip(10).Take(2).ToArray()));
	
	int s = Int32.Parse(new string(str.Skip(12).Take(2).ToArray()));*/
	
	Func<int[], int> a = i =>
	{
		int rez = 0;
	
		for(int j = 0; j < i.Length; j++)
		{
			rez += i[j] * (int)Math.Pow(10, i.Length - j - 1);
		}
		
		return rez;
	};
	
	int y = a(tarr.Take(4).ToArray());
	
	int M = a(tarr.Skip(4).Take(2).ToArray());
	
	int d = a(tarr.Skip(6).Take(2).ToArray());
	
	int h = a(tarr.Skip(8).Take(2).ToArray());
	
	int m = a(tarr.Skip(10).Take(2).ToArray());
	
	int s = a(tarr.Skip(12).Take(2).ToArray());
	
	//(y + " " + M + " " + d + " " + h + " " + m + " " + s).Dump();
	
	return new DateTime(y, M, d, h, m, s);
}

bool anyStar(string str, string starStr)
{
	if(str.Length == starStr.Length)
	{
		for(int i = 0; i < starStr.Length; i++)
		{
			if(starStr[i] != '*' && starStr[i] != str[i])
				return false;
		}
	}
	else
		return false;
	
	return true;
}