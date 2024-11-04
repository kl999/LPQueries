<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var a = 3;
	ref var b = ref a;
	
	b.Dump();
	
	b = 5;
	
	a.Dump();
}

ref int ReturnReference(ref int r, ref int r2){
	return ref r;
}

/*ref int Wrapper(ref int r){
	var i = 12;
	// Cannot use a result of 'Program.ReturnReference(ref int, ref int)'
	// in this context because it may expose variables referenced by
	// parameter 'r2' outside of their declaration scope
	return ref ReturnReference(ref r, ref i);
}*/
