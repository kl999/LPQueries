<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Thread trd = new Thread(() => { int a = 5; });

trd.Start();

trd.ThreadState.Dump();

Thread.Sleep(500);

(trd.ThreadState == System.Threading.ThreadState.Stopped).Dump();