<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
	
	var t = new tst(){ zxc = 15, qwe = Int64.MaxValue };
	
	Stream s = File.Open(@"c:\sp\bin.XVI32", FileMode.Create);
	
	f.Serialize(s, t);
	s.Close();
}

[Serializable()]
[StructLayout(LayoutKind.Sequential)]
class tst
{
	public ushort zxc = 0;
	public long qwe = 0;
}