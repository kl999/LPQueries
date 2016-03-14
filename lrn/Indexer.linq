<Query Kind="Program" />

void Main()
{
	index i = new index();
	i.Add("a");
	i[0] = 1000;
	int len = i[0];
	len.Dump();
	
	(i["1000"] + "ind").Dump();
	
	i["1000"] = "many letters";
	
	i.ind.Dump();
}

class index
{
	public List<string> ind = new List<string>();
	
	public void Add(string str)
	{
		ind.Add(str);
	}
	
	public int this [int i]
	{
		get
		{
			return ind[i].Length;
		}
		
		set
		{
			ind[i] = value.ToString();
		}
	}
	
	public string this [string str]
	{
		get
		{
			return ind.First(i=>i==str) + "|";
		}
		set
		{
			string s = value + " : " + ind.Count;
			ind.Add(s);
		}
	}
}
