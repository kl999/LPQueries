<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	double al = 1024,
		bl = 128;
	
	double[] a = new double[(int)al];
	double[] b = new double[(int)bl];
	
	/*for(int i = 1; i <= al; i++)
	{
		a[i - 1] = (i * bl) / al;
	}
	
	for(int i = 1; i <= bl; i++)
	{
		b[i - 1] = (i * al) / bl;
	}
	
	a.Dump();
	b.Dump();*/
	
	a.Select((i, ind) =>
		new{ind, rez = getIndFor2nd(ind, (int)al, (int)bl)}
	).Dump("rez A");
	b.Select((i, ind) =>
		new{ind, rez = getIndFor2nd(ind, (int)bl, (int)al)}
	).Dump("rez B");
}

int[] getIndFor2nd(int ind, int myLen, int twoLen)
{
	List<int> rez = new List<int>();

	double dOtherInd = ((double)(ind + 1) * (double) twoLen) / (double)myLen;
	
	if(myLen > twoLen)
	{
		dOtherInd -= 0.000000001;
		
		rez.Add((int)dOtherInd);
	}
	else
	{
		int prev = (int)(((double)ind * (double) twoLen) / (double)myLen);
		
		int ct = (int)dOtherInd - prev;
		
		//rez.Add(prev); rez.Add(ct);
		
		for(int i = 0; i < ct; i++)
		{
			rez.Add(prev + i);
		}
	}
	
	return rez.ToArray();
}