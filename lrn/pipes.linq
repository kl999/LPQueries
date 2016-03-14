<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.IO.Pipes</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

NamedPipeServerStream srv = null;
StreamWriter wrtr = null;

DumpContainer dc = new DumpContainer();

void Main()
{
	dc.Dump();
	
	using(
	srv = new NamedPipeServerStream(
		"myPipe",
		PipeDirection.InOut,
		1,
		PipeTransmissionMode.Byte,
		PipeOptions.None,
		200000000,
		200000000
	))
	{
		srv.WaitForConnection();
		
		wrtr = new StreamWriter(srv);
		
		var sarr = new[]
		{
			"Hello!",
			"I am server.",
			"Now I send thousand strings."
		};
		foreach(var s in sarr)
			writeStr(s);
		
		for(int i = 0; i < 1000; i++)
			writeStr("String no. " + i);
		
		srv.Disconnect();
		"End".Dump();
	}
}

void writeStr(string str)
{
	dc.Content = str;
	
	wrtr.WriteLine(str);
	
	wrtr.Flush();
	
	srv.WaitForPipeDrain();
}