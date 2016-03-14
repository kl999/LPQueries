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
	Test.Main();
}

public class Test
{
	public static void Main()
	{
		var dynMeth = new DynamicMethod ("Foo", null, null, typeof (Test));
		ILGenerator gen = dynMeth.GetILGenerator();
		gen.EmitWriteLine ("Hello world");
		gen.Emit (OpCodes.Ret);
		dynMeth.Invoke (null, null); // Hello world
	}
}