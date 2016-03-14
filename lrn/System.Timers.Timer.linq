<Query Kind="Program">
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

System.Timers.Timer tmr = null;

void Main()
{
    tmr = new System.Timers.Timer();
    tmr.Interval = 1000;
    tmr.Elapsed += new System.Timers.ElapsedEventHandler(timerMain_Elapsed);
    tmr.AutoReset = false;
    
    tmr.Start();
}

private void timerMain_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
{
    //Thread.Sleep(500);
    
    ("Z - " + DateTime.Now.ToString("HH:mm:ss.fff")).Dump();
    
    tmr.Interval = 1000 - DateTime.Now.Millisecond;
    
    tmr.Start();
    
    tmr.Dump();
}