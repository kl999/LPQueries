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

var arr = new[]{ 1, 2, 3, 4 };

using(var en = (arr as IEnumerable<int>).GetEnumerator())
{
    try
    {
        en.Current.Dump();
    }
    catch(InvalidOperationException ex)
    {
        ex.Dump("Error!");
    }
    
    for(; en.MoveNext();)
    {
        int val = en.Current.Dump();
    }
}