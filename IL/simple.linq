<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var o = new ILCl();
	
	o.invokeIL();
}

class ILCl
{
	DynamicMethod dynMtd;
	
	public ILCl()
	{
		ILMake();
	}
	
	void ILMake()
	{
		dynMtd = new DynamicMethod("myDynMtd", null, null, typeof(ILCl));
		
		ILGenerator gen = dynMtd.GetILGenerator();
		
		gen.Emit(OpCodes.Ldc_I4, 459); //~ = 459
		
		LocalBuilder firsrVar = gen.DeclareLocal(typeof(int)); //int firstVar = 459
		
		gen.Emit(OpCodes.Stloc, firsrVar); //~ --||--
		
		gen.Emit(OpCodes.Ldloc, firsrVar); //~ --||--
		
		//gen.Emit(OpCodes.Pop);
		
		MethodInfo writeLineInt = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) });
		
		gen.Emit (OpCodes.Call, writeLineInt); //~ Console.WriteLine(firstVar)
		
		gen.Emit(OpCodes.Ret); //~ return
	}
	
	public void invokeIL(){ dynMtd.Invoke(null, null); }
}