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

unsafe void Main()
{
	var a = new asd();
	
	a.instr.a = 254;
	a.instr.end = 111;
	
	a.instr.b = Int64.MaxValue - 2;
	
	a.buf[8] += 1;
	
	for(int i = 0; i < 20; i++)
		a.buf[i].Dump();
	
	sizeof(asd).Dump("Size");
	
	a.instr.Dump("str");
	
	str2 z;
	
	str2* zp = &z;
	
	zp->b = 5;
	
	z.Dump();
	
	str2* z2p = stackalloc str2[1];
	
	z2p->Dump();
}

[StructLayout(LayoutKind.Explicit)]
unsafe struct asd
{
	[FieldOffset(0)] public fixed byte buf[20];
	
	[FieldOffset(0)] public str2 instr;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
unsafe struct str2
{
	public byte a;
	public long b;
	public byte end;
}