<Query Kind="Program">
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

static void Main()
{
	Foo();
	
	my.clean();
	
	some_method();
}

static void Foo (
	[CallerMemberName]string memberName = null,
	[CallerFilePath]string filePath = null,
	[CallerLineNumber]int lineNumber = 0
	)
{
	Console.WriteLine (memberName);
	
	if(memberName != "Main")
		"Not in main!".Dump("Warning");
	
	Console.WriteLine (filePath);
	Console.WriteLine (lineNumber);
}

static void some_method()
{
	Foo();
}