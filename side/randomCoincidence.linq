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

var rand = new Random();

for(ulong i = 0; i != ulong.MaxValue; i++)
{
    if(i > 1111) i = 0;
    
    var n = (1000 + rand.Next(8999))
        //.Dump()
    ;
    
    var str = n.ToString();
    
    var istr = i.ToString();
    if(str[0] == str[1] && str[0] == str[2] && str[0] == str[3] && istr.Length == istr.Where(o => o == str[0]).Count())
    {
        $"{n}|{i}".Dump();
        
        break;
    }
}