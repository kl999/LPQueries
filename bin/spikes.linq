<Query Kind="Program" />

void Main()
{
	/*Random rand = new Random((int)(DateTime.Now.Hour * 10 
								+ DateTime.Now.Millisecond / 100));
	Random secondTierRand = new Random(DateTime.Now.Minute + DateTime.Now.Second);*/
	
	Rand rand = new Rand();
	
	Rand secondTierRand = new Rand();
	
	List<int> rez = new List<int>();
	
	int devCount = 0;
	
	for(int i = 0; i < 1000; i++)
	{
		int dev = secondTierRand.Next(100);
		
		if(dev < 90)
		{
			rez.Add(400 + rand.Next(200));
		}
		else
		{
			devCount++;
		
			for(;;)
			{
				int devNum = rand.Next(1000);
				if(devNum > 200 && devNum < 800)
				{ }
				else
				{
					rez.Add(devNum);
					break;
				}
			}
		}
	}
	
	//rez = rez.OrderBy(i => i).ToList();
	
	devCount.Dump("deviation");
	
	rez.Dump();
}

class Rand
{
	System.Security.Cryptography.RandomNumberGenerator rand = System.Security.Cryptography.RandomNumberGenerator.Create();
	
	double ret()
	{
		
		byte[] b = new byte[4];
		rand.GetBytes(b);
		return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
	}
	
	public int Next(int i)
	{
		return (int)((double)i * ret());
	}
}
