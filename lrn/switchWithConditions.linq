<Query Kind="Program" />

void Main()
{
    var rand = new Random();
    
    switch (rand.Next(100))
    {
        case int a when a < 20:
        "<20".Dump();
        break;
        
        case int a when a < 50:
        "20><50".Dump();
        break;
        
        case int a when a < 70:
        "50><70".Dump();
        break;
        
        default:
        "def".Dump();
        break;
    }
    
    object z = new DateTime();
    
    switch (z)
    {
        case B b:
        "is B".Dump();
        break;
        
        //not first
        case A x:
        "is A".Dump();
        break;
        
        case C c:
        "is C".Dump();
        break;
        
        default:
        "is unknown".Dump();
        break;
    }
}

class A
{
    
}

class B : A
{
    
}

class C
{
    
}