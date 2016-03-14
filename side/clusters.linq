<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Random rand = new Random();
	
	int trueNum = rand.Next(4) + 3;
	
	trueNum.Dump("trueNum");
	
	int[] inp = new int[100];
	
	for(int i = 0; i < inp.Length; i++)
	{
		inp[i] = (1 + rand.Next(trueNum)) * 1000 - 5 + rand.Next(10);
	}
	
	inp.Dump();
	
	predefCl(trueNum, inp).Dump("1001");
	
	defCl(inp).Dump("def 1001");
	
	int[] randInp = new int[100];
	
	randInp = randInp.Select(i => rand.Next(1000)).ToArray();
	
	//predefCl(5, randInp).Dump("random");
	
	int[] decInp = new int[100];
	
	decInp = decInp.Select((i,ind) => 100 - ind).ToArray();
	
	//predefCl(5, decInp).Dump("dec");
}

List<rezCl> predefCl(int clNum, int[] inp)
{
	var rez = new List<rezCl>();

	for(int i = 0, ct = 0; ct < clNum; i++)
	{
		int t = inp[i];
		
		bool found = false;
		foreach(rezCl o in rez)
		{
			if(o.id == t)
			{
				found = true;
				
				break;
			}
		}
		
		if(!found)
		{
			rez.Add(new rezCl(t));
			ct++;
		}
	}
	
	findCl(inp, rez);
	
	foreach(rezCl o in rez)
	{
		o.cl = o.cl.OrderBy(i => i).ToList();
	}

	return rez;
}

void findCl(int[] inp, List<rezCl> rez)
{
	for(;;)
	{	
		int ct = rez.Count;
		
		int[] rezOldCenters = rez.Select(i => i.id).ToArray();
		
		foreach(rezCl o in rez)
		{
			o.cl.Clear();
		}
	
		foreach(int i in inp)
		{
			int min = Math.Abs(i - rez[0].id), minN = 0;
			
			int j;
			for(j = 0; j < ct; j++)
			{
				int tmp = Math.Abs(i - rez[j].id);
				
				if(tmp < min)
				{
					min = tmp;
					
					minN = j;
				}
			}
			
			rez[minN].cl.Add(i);
		}
		
		bool chCenter = false;
		
		for(int i = 0; i < ct; i++)
		{
			
			if(rez[i].cl.Count > 0)
			{
				rez[i].id = (rez[i].cl.Min() + rez[i].cl.Max()) / 2;
				
				//rez[i].id = (int)rez[i].cl.Average();
			}
			
			if(rez[i].id != rezOldCenters[i]) chCenter = true;
		}
		
		if(!chCenter)
			break;
	}
}

List<rezCl> defCl(int[] inp)
{
	List<rezCl> rez = new List<rezCl>();
	
	int[] ordInp = inp.OrderBy(i => i).ToArray();
	
	int[] inpDifR = ordInp.Select((i, ind) =>
	{
		if(ind == 0) return 0;
		else
			return i - ordInp[ind - 1];
	}).ToArray().Dump();
	
	for(int i = 1; i < ordInp.Length; i++)
	{
		
	}

	return rez;
}

class rezCl
{
	public int id = 0;
	
	public List<int> cl = new List<int>();
	
	public rezCl(int _id)
	{
		id = _id;
	}
}