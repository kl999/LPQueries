<Query Kind="Program" />

void Main()
{
	var b = new B(){ str = "Hi" };
	
	a(ref b);
	
	b.Dump();
	
	c(b);
	
	b.Dump();
}

void a(ref B b)
{
	b = new B(){ str = "World" };
}

void c(B b)
{
	b = new B(){ str = "asd" };
}

class B
{
	public string str;
}