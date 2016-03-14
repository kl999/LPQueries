<Query Kind="Statements">
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

var bmp = new Bitmap(@"c:\sp\testStress.bmp");

var w = bmp.Width;

var buf = bmp.getGrayBytes();

var str = "";

for(int i = 0; i < buf.Length; )
{
    str += string.Join("", buf.Skip(i).Take(w).Select(o => Math.Round((o / 255.0) * 9))) + "\n";
    i += w;
}

str.Dump();