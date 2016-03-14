<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
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
    str a = new str(10),
        b = new str(-1);
    
    a.ToString().Dump("a");
    b.ToString().Dump("b");
    
    new str(a.i ^ b.i).ToString().Dump("Rez");
}

[StructLayout(LayoutKind.Explicit)]
unsafe struct str
{
    public str(int _i)
    {
        i = _i;
    }
    
	[FieldOffset(0)] public fixed byte buf[8];
	
	[FieldOffset(0)] public int i;
    
    public override string ToString()
    {
        var rez = new StringBuilder("Int is: " + i
            + Environment.NewLine
            + "bytes are:"
            + Environment.NewLine);
        
        fixed(byte* ptr = buf)
        for(int o = 0; o < 8; o++)
        {
            byte num = ptr[o];
            rez.AppendLine(num.ToString());
        }
        
        return rez.ToString();
    }
}