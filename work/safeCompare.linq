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
	var sw = new Stopwatch();
	sw.Start();

	var form = new formCl(20, 20);
	
	var tempt = new temptCl(10, 10);
	
	int w = form.w, h = form.h,
		tw = tempt.w, th = tempt.h;
	
	int[][] wto2 = new int[tw][];
	int[][] hto2 = new int[th][];
	
	wto2 = wto2.Select((i, ind) => getIndFor2nd(ind, tw, w)
		).ToArray();
	
	hto2 = hto2.Select((i, ind) => getIndFor2nd(ind, th, h)
		).ToArray();
	
	double tsum = 0;
	
	double[,] map = tempt.map;
	
	for (int x = 0; x < tw; x++)
	{
		for (int y = 0; y < th; y++)
		{
			double val = map[x, y];
			
			double tmp = 0;
			int ct = 0;
			
			for (int i = 0; i < wto2[x].Length; i++)
				for (int j = 0; j < hto2[y].Length; j++)
				{
					if (form.map[wto2[x][i], hto2[y][j]])
					{
						tmp++;
						ct++;
					}
					else
						ct++;
				}
			
			tsum += (tmp / ct) * val;
		}
	}
	
	if (tsum < 0)
	{
		"0%".Dump();
	}
	else
	{
		((int)((tsum / (double)tempt.sum) * 100) + "%").Dump();
	}
	
	sw.Stop();
	sw.ElapsedTicks.Dump("Time");
}

int[] getIndFor2nd(int ind, int myLen, int twoLen)
{
	List<int> rez = new List<int>();
	
	double dOtherInd = ((double)(ind + 1) * (double)twoLen) / (double)myLen;
	
	if (myLen > twoLen)
	{
		dOtherInd -= 0.000000001;
		
		rez.Add((int)dOtherInd);
	}
	else
	{
		int prev = (int)(((double)ind * (double)twoLen) / (double)myLen);
		
		int ct = (int)dOtherInd - prev;
		
		//rez.Add(prev); rez.Add(ct);
		
		for (int i = 0; i < ct; i++)
		{
			rez.Add(prev + i);
		}
	}

  return rez.ToArray();
}
	
class formCl
{
	public bool[,] map;
	
	public int w = 20, h = 20;
	
	public formCl(int _w, int _h)
	{
		w = _w; h = _h;
	
		map = new bool[w, h];
		
		for(int i = 0; i < h - 1; i++)
		{
			map[0, i] = map[1, i] = true;
		}
	}
}

class temptCl
{
	public double[,] map;
	
	public int w = 20, h = 20, sum = 0;
	
	public temptCl(int _w, int _h)
	{
		w = _w; h = _h;
	
		map = new double[w, h];
		
		double tsum = 0;
		
		for(int x = 0; x < w; x++)
		for(int y = 0; y < h; y++)
		{
			map[x, y] = -1;
			
			if(x == 0) map[x, y] = 1;
			
			if(map[x, y] > 0) tsum += map[x, y];
		}
		
		sum = (int)tsum;
	}
}