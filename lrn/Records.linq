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
}

record A
{
    public int B { get; init; }
}

record B(int C, string D);