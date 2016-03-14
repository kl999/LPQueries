<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	for(int i = 0; i < 100000; i++)
		ThreadPool.QueueUserWorkItem(Hi, i);
}

void Hi(object i)
{
	Thread.Sleep(100);
	
	("Hello" + i).Dump();
}