<Query Kind="Statements">
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

var t = new Task(() => { Thread.Sleep(2000); throw new Exception("Ex1");; });
var t2 = t.ContinueWith((prez) => { Thread.Sleep(2000); throw new Exception("Ex2"); });

t.Start();

try
{
    t2.Wait();
}
catch(Exception ex)
{
    ex.Dump("catched");
}

try
{
    Task.WaitAll(new[] {t, t2});
}
catch(Exception ex)
{
    ex.Dump("catched");
}

"End".Dump();