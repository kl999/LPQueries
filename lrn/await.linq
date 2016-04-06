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

async void Main ()
{
    $"0 {Thread.CurrentThread.ManagedThreadId}".Dump();
    var t = DoSomeStuff();
    $"a {Thread.CurrentThread.ManagedThreadId}".Dump();
    
    t.Wait();
    
    $"1 {Thread.CurrentThread.ManagedThreadId}".Dump();
    await DoSomeStuff();
    $"a {Thread.CurrentThread.ManagedThreadId}".Dump();
}

async Task DoSomeStuff()
{
    var text = await MyMethodTaskAsync();
    $"b {Thread.CurrentThread.ManagedThreadId}".Dump();
    (text).Dump();
}

async Task<string> MyMethodTaskAsync()
{
    await Task.Delay(5000);
    
    $"c {Thread.CurrentThread.ManagedThreadId}".Dump();
    return "asd";
}