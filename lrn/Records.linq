<Query Kind="Program" />

void Main()
{
    A a = new(){ B = 5, };
    
    a.Dump();
    
    B b = new(5, "z") { D = "x" };
    
    //b.D = "error";
    
    b.Dump();
    
    (a == new A{ B = 5 }).Dump();
    
    (b with { D = null }).ToString().Dump();
	
	new A().Dump();
	//new B(); //Error
	new E().Dump();
	new H().Dump();
}

record A
{
    public int B { get; init; }
}

record B(int C, string D);

record struct E(int F, string G);

record struct H(int I, string J)
{
	public int I { get; init; } = I;
	public string J { get; init; } = J;
}