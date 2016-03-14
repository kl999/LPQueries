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
	byte[] inp = File.ReadAllBytes(@"c:\sp\1.png");//getBMap("11100");
	
	byte[] poly = getBMap("1101");
	
	int addbits = poly.Length - 1;
	
	byte[] addinp = new byte[inp.Length + addbits];
	
	for(int i = 0; i < inp.Length; i++)
	{
		addinp[i] = inp[i];
	}
	
	for(bool stop = false; !stop; )
	{
		for(int i = 0; i < inp.Length; i++)
		{
			stop = true;
			
			if(addinp[i] == 1)
			{
				xor(addinp, poly, addbits, i);
				
				stop = false;
				break;
			}
		}
	}
	
	//addinp.Dump();
	
	byte[] rez = new byte[addbits];
	
	for(int i = inp.Length; i < addinp.Length; i++)
	{
		rez[i - inp.Length] = addinp[i];
	}
	
	rez.Dump();
}

byte[] getBMap(string inp)
{
	byte[] rez = new byte[inp.Length];
	
	for(int i = 0; i < inp.Length; i++)
	{
		if(inp[i] == '1')
			rez[i] = 1;
		else
			rez[i] = 0;
	}
	
	return rez;
}

void xor(byte[] addinp, byte[] poly, int addbits, int pos)
{
	for(int i = 0; i < poly.Length; i++)
	{
		addinp[pos + i] ^= poly[i];
	}
}