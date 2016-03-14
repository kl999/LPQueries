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

var sw = new Stopwatch();

sw.Restart();
long len = 100000;
long[] arr = new long[len];
arr[0] = 2;
for(long i = 2, cur = 1; arr[len - 1] == 0; i++)
{
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
    }
}
sw.Stop();
sw.Dump();

sw.Restart();
var myPrimes = new long[len * 100];
myPrimes[0] = 1;
var arr2 = new long[len];

bool swtch = true;
int cur2 = 0, cur3 = 1, cur4 = 0;
for(;;)
{
    if(arr2[len - 1] != 0) break;
    
    long rez = 0;
    if(swtch)
    {
        rez = myPrimes[cur2] * 2 - 1;
        
        swtch = !swtch;
    }
    else
    {
        rez = myPrimes[cur2] * 2 + 1;
        
        cur2++;
        if(cur2 == 1) cur2++;
        
        swtch = !swtch;
    }
    
    myPrimes[cur3++] = rez;
    
    if(rez == 1) continue;
    
    bool found = false;
    for(int o = 0; o < cur4; o++)
    {
        if(rez % arr2[o] == 0)
        {
            found = true;
            break;
        }
    }
    
    if(!found) arr2[cur4++] = rez;
}
sw.Stop();
sw.Dump();

arr2.Dump();