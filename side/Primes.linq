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

var dc = new DumpContainer();
dc.Dump();
var curDc = new DumpContainer();
curDc.Dump();
curDc.Content = 1;

long[] arr = new long[100000];
arr[0] = 2;

for(long i = 2, cur = 1; arr[99999] == 0; i++)
{
    if(i % 1000 == 0) dc.Content = i;
    
    bool found = false;
    for(long o = 0; o < cur; o++)
    {
        if(i % arr[o] == 0)
        {
            found = true;
            break;
        }
    }
    
    if(!found)
    {
        arr[cur] = i;
        cur++;
        curDc.Content = cur;
        //arr.Dump();
    }
}

arr.Dump("Rez");