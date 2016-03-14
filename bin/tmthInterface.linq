<Query Kind="Program" />

void Main()
{
	myCl c1 = new myCl(3);
	
	c1.Dump();
	
	myCl c2 = c1;
	
	c1.i = 10;
	
	c2.Dump();
	
	aCl acl = new aCl();
	
	dirCl dir = new dirCl("acl", acl);
	
	a acl2 = dir.ret("acl");
	
	acl2.name = "hi";
	
	acl2.Dump();
	
	List<a> alist = new List<a>();
	
	alist.Add(acl2);
	
	acl2.name = "no";
	
	alist.Dump();
}

class myCl
{
	public int i;
	
	public myCl(int i)
	{
		this.i = i;
	}
}

interface a
{
	string name{get; set;}
	
	a New();
}

class aCl : a
{
	public string name{get; set;}
	
	public a New()
	{
		return new aCl();
	}
}

class dirCl
{
	string N;
	a Ty;

	public dirCl(string n, a t)
	{
		N = n;
		Ty = t;
	}
	
	public a ret(string n)
	{
		if(n == N)
		{
			return Ty.New();
		}
		return null;
	}
}