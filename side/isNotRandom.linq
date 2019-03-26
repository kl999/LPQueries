<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var ct = 10000;
    
    var rand = new Random();
    
    var arr = new int[ct];
    
    for(int i = 0; i < ct; i++)
    {
        arr[i] = rand.Next(100);
    }
    
    var dif = new int[100];
    
    for(int i = 0; i < ct; i++)
    {
        dif[arr[i]]++;
    }
    
    dif
    .Select((i, ind) => new{ num = ind, ct = i })
    //.OrderByDescending(i => i.ct).Dump()
    .Chart(i => i.num, i => i.ct).DumpInline(750, 500)
    ;
    
    arr
    .Take(1000)
    .Select((i, ind) => new{ ord = ind, num = i })
    .Chart(i => i.ord, i => i.num)
    .DumpInline(5000, 500);
    
    @"
    
    
    
--------------Crypto Rand----------------------
".Dump();
    
    var rand2 = new Random();
    
    var arr2 = new int[ct];
    
    for(int i = 0; i < ct; i++)
    {
        arr2[i] = rand2.Next(100);
    }
    
    var dif2 = new int[100];
    
    for(int i = 0; i < ct; i++)
    {
        dif2[arr2[i]]++;
    }
    
    dif2
    .Select((i, ind) => new{ num = ind, ct = i })
    //.OrderByDescending(i => i.ct).Dump()
    .Chart(i => i.num, i => i.ct).DumpInline(750, 500)
    ;
    
    arr2
    .Take(1000)
    .Select((i, ind) => new{ ord = ind, num = i })
    .Chart(i => i.ord, i => i.num)
    .DumpInline(5000, 500);
}

class rand
{
	Random random = new Random(DateTime.Now.Minute);

	public double NextDouble()
	{
		var rand = System.Security.Cryptography.RandomNumberGenerator.Create();
		/*byte[] buf = new byte[4];
		rand.GetBytes(buf);
		int i = 0;
		
		foreach(byte bt in buf)
		{
			i += (int)bt;
		}
		
		double rez = (double)i / (255 * buf.Length);
		
		return rez;*/
		
		byte[] b = new byte[4];
		rand.GetBytes(b);
		return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
	}
    
    public double Next(int max)
	{
		var rand = System.Security.Cryptography.RandomNumberGenerator.Create();
		/*byte[] buf = new byte[4];
		rand.GetBytes(buf);
		int i = 0;
		
		foreach(byte bt in buf)
		{
			i += (int)bt;
		}
		
		double rez = (double)i / (255 * buf.Length);
		
		return rez;*/
		
		byte[] b = new byte[4];
		rand.GetBytes(b);
		return (int)(((double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue) * max);
	}
}