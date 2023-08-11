<Query Kind="Statements">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var arr = new[]{ 1, 2 }.AsParallel().Select(i => { Thread.Sleep(1000); i.Dump(); return i + 1; }).ToArray();
arr.Dump();

Thread.CurrentThread.ManagedThreadId.Dump("start");

new int[]{ 1, 2, 3 }
.AsParallel()
.Select(i =>
{
	Thread.CurrentThread.ManagedThreadId.Dump($"{i}");
	return i + 1;
})
.AsSequential()
.Select(i => i.Dump())
.ToArray()
;