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

object locker = new object();

void Main()
{
    Task.Run(() => { Thread.Sleep(1000); Monitor.Enter(locker); Monitor.Pulse(locker); Monitor.Exit(locker); });
    
    Task.Run(() => { Monitor.Enter(locker); Monitor.Wait(locker); "End".Dump(); Monitor.Exit(locker); }).Wait();
    
    Task.Run(() => { Thread.Sleep(1000); lock(locker){ Monitor.Pulse(locker); } });
    
    Task.Run(() => { lock(locker){ Monitor.Wait(locker); "End".Dump(); } }).Wait();
    
    for(int i = 0; i < 20; i++)
    {
        new Thread(wait).Start();
        
        Thread.Sleep(2500);
    }
}

void wait()
{
    if(Monitor.TryEnter(locker, 0))
    {
        "Run".Dump();
        Thread.Sleep(5000);
        Monitor.Exit(locker);
        "end".Dump();
    }
    else
        "denied".Dump();
}