<Query Kind="Program" />

void Main()
{
	var sorted = new SortedList <string, MethodInfo>();
	
	Type tp = typeof(myCl);
	
	foreach (MethodInfo m in tp.GetMethods())
	{
		if(m.DeclaringType != typeof(object))
		{
			sorted [m.Name] = m;
		}
	}
	
	foreach (string name in sorted.Keys)
	Console.WriteLine (name);
	
	"----------------------------------------------".Dump();
	
	foreach (MethodInfo m in sorted.Values)
	Console.WriteLine (m.Name + " returns a " + m.ReturnType);
	
	"----------------------------------------------".Dump();
	
	foreach (MethodInfo m in sorted.Values)
	Console.WriteLine (m.Invoke(new myCl(), new object[] { 1 }));
}

class myCl
{
	void privMethod()
	{
		
	}
	
	public int pubMethod(int a)
	{
		return a * 10;
	}
}