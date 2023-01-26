<Query Kind="Statements">
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Guid g;
for(int i = 0; i < 1; i++)
{
    g = Guid.NewGuid();
    g.Dump("std, Len: " + g.ToString().Length.ToString());
    var asBase64 = System.Convert.ToBase64String(g.ToByteArray());
    asBase64.Dump("Base64, Len: " + asBase64.Length.ToString());
    
    foreach(var format in new[]{ "N", "D", "B", "P", "X" })
        g.ToString(format).Dump(format + ", Len: " + g.ToString(format).Length.ToString());
}