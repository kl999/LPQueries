<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
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
	var pc = new ProcControl();

	bool pinged = false;
	
	string buf = "";
	for (; ; )
	{
		if (pc.rdr.Peek() < 0 && pc.p.HasExited) break;
		
		char nch = (char)pc.rdr.Read();
		
		buf += nch;
		
		Console.Write(nch);
		
		if (nch == '>' && Regex.IsMatch(buf.Split('\n').Last(), @"[A-Z]:\\.*>"))
		{
			if(!pinged)
			{
				pc.wrtr.Write("ping kaspi-webt\r\n");
				
				pc.wrtr.Flush();
				
				pinged = true;
			}
			else
			{
				pc.p.Kill();
				
				break;
			}
		}
	}
}

class ProcControl
{
	public StreamReader rdr = null;
	public TextWriter wrtr = null;
	
	public Process p = null;
	
	public ProcControl()
	{
		p = new Process()
		{
			StartInfo = new ProcessStartInfo()
			{
				FileName = "cmd.exe",
				CreateNoWindow = true,
				UseShellExecute = false,
				ErrorDialog = false,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				WindowStyle = ProcessWindowStyle.Maximized,
				Arguments = ""
			},
			EnableRaisingEvents = true
		};
		
		p.Start();
		
		rdr = new StreamReader(
			p.StandardOutput.BaseStream,
			Encoding.GetEncoding(866)
		);
		
		wrtr = new StreamWriter(
			p.StandardInput.BaseStream,
			Encoding.GetEncoding(866)
		);
	}
}

// Define other methods and classes here