<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.IO.Pipes</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Task.Run(() =>
{
	using (var s = new NamedPipeServerStream ("pipedream"))
	{
		s.WaitForConnection();
		//for(int i = 0; i < Int32.MaxValue; i++)
		s.WriteByte(100);
		Console.WriteLine ("Server says: " + s.ReadByte());
	}
});

Task.Run(() =>
{
	using (var s = new NamedPipeClientStream ("pipedream"))
	{
		s.Connect();
		//for(int i = 0; i < Int32.MaxValue; i++)
		//s.ReadByte();
		Console.WriteLine ("Client says: " + s.ReadByte());
		s.WriteByte(200); // Send the value 200 back.
	}
});