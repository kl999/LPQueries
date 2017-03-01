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

byte key = Convert.ToByte("1111 1111".Replace(" ", ""), 2).Dump("key");

var fileIn = Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), "Desktop", "in.bin")
.Dump()
;
var fileOut = Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), "Desktop", "out.bin")
.Dump()
;

using(var instr = File.OpenRead(fileIn))
using(var outstr = File.OpenWrite(fileOut))
{
    for(int b = instr.ReadByte(); b != -1; b = instr.ReadByte())
    {
        byte t = (byte)(b ^ key);
        
        //t.Dump();
        
        outstr.WriteByte(t);
    }
}