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

//Test 1

Encoding.GetEncoding(866).GetString(new byte[] {254}).Dump();

Encoding.Unicode.GetBytes("■").Dump();

Encoding.Unicode.GetString(new byte[] { 254, 0 }).Dump();

Encoding.UTF8.GetString(new byte[] { 254 }).Dump();

"------------".Dump();

string[,] a = new string[256, 3];
for(byte i = 0; i <= 254; i++)
{
    a[i, 0] = Encoding.Unicode.GetString(new byte[] { i, 0 });
    
    if(i < 127)
        a[i, 1] = Encoding.UTF8.GetString(new byte[] { i });
    else
        a[i, 1] = Encoding.UTF8.GetString(new byte[] { 127, i  });
    
    a[i, 2] = i.ToString();
}

for(byte i = 0; i <= 254; i++)
{
    ("" + a[i, 0] + "\t" + a[i, 1] + "\t" + a[i, 2]) .Dump();
}