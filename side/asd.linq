<Query Kind="Program" />

void Main()
{
	new b().read().Dump();
	
	MyExtensions.hi().Dump();
}

class a
{
	public virtual string get()
	{ return "A!"; }
	
	public string read()
	{ return get(); }
}

class b : a
{
	public override string get()
	{
		return "B!";
	}
}