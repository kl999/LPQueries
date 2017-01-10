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
    int steps = 0;
    int requiredValue = 96;
    foreach(var item in randList())
    {
        steps++;
        if(item == requiredValue)
        {
            $"Found {requiredValue} in {steps} steps".Dump();
            break;
        }
    }
}

IEnumerable<int> randList()
{
    var rand = new Random();
    for(;;) yield return rand.Next(101);
}