<Query Kind="Program" />

void Main()
{
	#region var
	FileStream file = File.Open("C:\\Users\\Psamarse\\Desktop\\LINQPad4\\path\\1.txt", FileMode.Open);
	#endregion
	
	byte[] buf = new byte[file.Length];
	
	file.Read(buf, 0, buf.Length);
	
	//buf.Dump();
	
	string rez = Encoding.UTF8.GetString(buf, 0, buf.Length)
															//.Dump()
															;
															
	
	file.Close();
												
	List<obj> objL = new List<obj>();
	
	objL.Add(new obj("nothing", "has nothing to do with"));
	
	{
		string[] tmp = rez.Split(';');
	
		foreach(string tstr in tmp)
		{
			string[] t2 = tstr.Split('-');
			objL.Add(new obj(t2[0], t2[1]));
		}
	}
	
	//objL.Dump();	
	
	DateTime curDate = DateTime.Now;
	
	Rand criptoRand = new Rand();
	
	for(;;)
	{
		Random rand = new Random(DateTime.Now.Second + (DateTime.Now.Hour * 10));
	
		int r1 = rand.Next(objL.Count);
		int r2;
		int r3;
		for(;;)
		{
			r2 = criptoRand.Next(objL.Count);
			if(r2!=r1)
			break;
		}
		if(rand.Next(10) >= 7)
		{
			for(;;)
			{
				r3 = rand.Next(objL.Count);
				if(r3!=r1)
				break;
			}
		}
		else
		{
			r3 = r1;
		}
		
		curDate = curDate.AddSeconds(rand.Next(1800));
		(curDate.ToString("HH:mm:ss") +  ": " + objL[r1].name + " " + objL[r3].does + " " + objL[r2].name).Dump();
		"".Dump();
		Thread.Sleep(5000);
	}
}

struct obj
{
	public string name;
	public string does;
	
	public obj(string _name, string _does)
	{
		name = _name;
		does = _does;
	}
}

class Rand
{
	System.Security.Cryptography.RandomNumberGenerator rand
		= System.Security.Cryptography.RandomNumberGenerator.Create();
	
	public double ret()
	{
		byte[] b = new byte[4];
		
		rand.GetBytes(b);
		
		return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
	}
	
	public int Next(int max)
	{
		return (int)(ret() * max);
	}
}