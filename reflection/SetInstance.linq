<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var inst = new testClass();

	Type t = typeof(testClass);
	
	FieldInfo wrField = t.GetField("writing",
		BindingFlags.Public |BindingFlags.Instance
		).Dump();
	
	wrField.SetValue(inst, "Hello Instance");
	
	inst.Dump();
	
	wrField.GetValue(inst).Dump();
}

class testClass
{
	public string writing = "Noooo!!!";
}