<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Numerics</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Good results
//ClRSA(197, 967, 5)
//ClRSA(197, 967, 59)
//ClRSA(197, 967, 31)
//ClRSA(197, 967, 1861) Good!!!
//ClRSA(197, 967, 14411) The Best!!!
//ClRSA(3557, 2579, 14667)
//ClRSA(3557, 2579, 32621)

void Main()
{
	var rsa = new ClRSA(197, 967, 14411);
	
	rsa.Dump();
	
	int msg = 598;
	
//	msg = new BigInteger(
//		new byte[] { 72, 101 }
//	);
	
	msg.Dump("Message");
	
	int cd = encode(msg, rsa.e, (int)rsa.n);
	
	cd.Dump("Encoded");
	
	var rez = rsa.decode(cd).Dump("Decoded");
	
	//Encoding.UTF8.GetString(rez.ToByteArray()).Dump();
	
	string msgStr = //"Hello world";string a =
@"First we look at the ReadLine method on StreamReader
and how you can use it with List. The .NET Framework
doesn't provide a ""Read All Lines"" method on StreamReader,
but our solution will fill that need.";
	
	int[] cdStr = encodeString(msgStr, rsa.e, rsa.n);
	
	msgStr.Dump("String to encode");
	
	cdStr.Dump();
	
	var bfmt = 
		new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
	
	using(var strm =
		new FileStream("c:\\sp\\code.1", System.IO.FileMode.Create))
	{
		bfmt.Serialize(strm, cdStr);
	}
	
	int[] ffcdStr;
	using(var strm =
		new FileStream("c:\\sp\\code.1", System.IO.FileMode.Open))
	{
		ffcdStr = (int[])bfmt.Deserialize(strm);
	}
	
	rsa.decodeString(ffcdStr).Dump("Decoded string");
}

public int encodebi(int inNum, int e, BigInteger n)
{
	if(inNum >= n)
		Console.WriteLine("Bad Message");

	BigInteger num = BigInteger.Pow(inNum, e);
	
	//num.ToString().Dump("BIG Enc");

	return (int)BigInteger.Remainder(num, n);
}

public int encode(int inNum, int e, int n)
{
	if(inNum >= n)
		Console.WriteLine("Bad Message");
		
	long powRem = 1;
	for(int i = 0; i < e; i++)
	{
		powRem = (powRem * inNum) % n;
		
		//powRem.Dump();
	}
	
	return (int)powRem;
}

int[] encodeString(string str, int e, BigInteger n)
{
	byte[] temp = Encoding.UTF8.GetBytes(str);
	
	int[] rez = new int[temp.Length];
	
	for(int i = 0; i < temp.Length; i++)
	{
		rez[i] = encode(temp[i], e, (int)n);
	}

	return rez;
}

class ClRSA
{
	//q prime, p dif prime
	public long
		q = 0,
		p = 0;
	
	//n = q * p
	public BigInteger n = 0;
	
	//ell = (q - 1) * (p - 1)
	public long ell = 0;
	
	public int e = 17;
	
	public int d = 0;
	
	public ClRSA(long _q, long _p, int _e)
	{
		q = _q;
		p = _p;
		
		e = _e;
		
		n = q * p;
		
		ell = (q - 1) * (p - 1);
		
		if(ell % e == 0)
			throw new Exception("Bad e");
		
		long m = ell;
		
		long[] r = new long[m];
		
		r[1] = 1;
		for (long i = 2; i < m; i++)
			r[i] = (m - (m / i) * r[m % i] % m) % m;
		
		long tmp = r[e];//r.Where(i => i > 1).Dump().Min().Dump();
		
		r.Select((i, ind) => 
		{
			if(i > 1)
				return String.Format("{0:N0} : {1:N0}",ind, (int)(i % ell));
			else
				return "nothing";
		})
		.Where(i => i != "nothing")

//		.OrderBy(i =>
//		{
//			string[] tmp2 = i.Split(':');
//			
//			return tmp2[0].Length;
//		})
//		.ThenBy(i =>
//		{
//			string[] tmp2 = i.Split(':');
//			
//			return tmp2[1].Length;
//		})

		.OrderBy(i =>
		{
			string[] tmp2 = i.Split(':');
			
			double l1 = tmp2[0].Length,
				l2 = tmp2[1].Length;
			
			if(l1 > l2)
			{
				double tmp3 = l2;
				l2 = l1;
				l1 = tmp3;
			}
			
			return (l2 + l1) * 1 + l2 - l1;
		})
		//.Dump()
		;
		
		d = (int)(tmp % ell);
	}
	
	public int decodebi(int code)
	{
		BigInteger num = BigInteger.Pow(code, d);
		
		//num.ToString().Dump("BIG Dec");
	
		return (int)BigInteger.Remainder(num, n);
	}
	
	public long decode(int code)
	{
		long powRem = 1;
		for(int i = 0; i < d; i++)
		{
			powRem = (powRem * code) % (long)n;
			
			//powRem.Dump();
		}
		
		return powRem;
	}
	
	public string decodeString(int[] buf)
	{
		List<byte> rezBytes = new List<byte>();
		
		foreach(int cd in buf)
		{
			rezBytes.Add((byte)decode(cd));
		}
		
		return Encoding.UTF8.GetString(rezBytes.ToArray());
	}
}