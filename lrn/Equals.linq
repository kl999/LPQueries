<Query Kind="Program" />

void Main()
{
	var a = new List<A>{ new(){ Id = 1 } };
	var b = new A{ Id = 1 };
	
	(a.Contains(b)).Dump();
	
	var c = new A{ Id = 1 };
	var d = new List<A>();
	
	d.Add(c);
	
	c.Id = 5;
	
	d.Contains(c).Dump();
	
	var e = new A{ Id = 1 };
	var f = new Dictionary<A, string>();
	
	f.Add(e, "Hi");
	
	e.Id = 5;
	
	f[e].Dump();
}

class A
{
	public int Id;
	
	public override int GetHashCode()
	{
		return Id;
	}
	
	public override bool Equals(object other)
	{
		return Id == (other as A)?.Id;
	}
}