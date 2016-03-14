<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

WebRequest.DefaultWebProxy = null;

WebClient wc = new WebClient();
wc.Proxy = null;
//wc.DownloadFile ("http://www.albahari.com/nutshell/code.aspx", "code.htm");
//System.Diagnostics.Process.Start ("code.htm");

var wc2 = new WebClient();
wc2.DownloadProgressChanged += (sender, args) =>
	Console.WriteLine (args.ProgressPercentage + "% complete");
Task.Delay (5000).ContinueWith (ant => wc2.CancelAsync());
//await wc2.DownloadFileTaskAsync ("http://oreilly.com", "webpage.htm");

/*WebRequest req = WebRequest.Create
("http://www.albahari.com/nutshell/code.html");
req.Proxy = null;
using (WebResponse res = req.GetResponse())
using (Stream rs = res.GetResponseStream())
{
	List<byte> buf = new List<byte>();
	for(int rez = 0;rez >= 0;)
	{
		rez = rs.ReadByte();
		buf.Add((byte)rez);
	}
	Encoding.UTF8.GetString(buf.ToArray()).Dump();
}*/

//await (new HttpClient().GetStringAsync ("http://linqpad.net")).Dump();

IPEndPoint extPoint = new IPEndPoint(IPAddress.Parse("109.238.163.228"), 80);

Socket server = new Socket(
	AddressFamily.InterNetwork,
	SocketType.Stream,
	ProtocolType.Tcp);
	
server.ReceiveTimeout = 5000;

//server.Send(Encoding.UTF8.GetBytes(Console.ReadLine()));

/*server.SetSocketOption(
	SocketOptionLevel.Tcp,
	SocketOptionName.KeepAlive,
	true);*/

server.Connect(extPoint);//http://beta.igo.kz/vasya.php?data=123&x=1

DateTime startTime = DateTime.Now;

server.Connected.Dump();

server.Send(
	Encoding.UTF8.GetBytes("GET /vasya.php?data=123&x=1 HTTP/1.0\nHost: beta.igo.kz\n\n")
	);
	
//Thread.Sleep(5000);

List<byte> endBuf = new List<byte>();

for(; ; )
{
	int avlbl = server.Available;
	
	if(avlbl > 0)
	{
		byte[] inBuf = new byte[avlbl];
		
		(
				"\n******************************"
			+	"\nms no.: " + (DateTime.Now - startTime).TotalMilliseconds
			+	"\nConnected: " + server.Connected
			//+	"\nReceiveBufferSize: " + server.ReceiveBufferSize
			+	"\nAvailable:" + server.Available
			+	"\nPollR:" + server.Poll(1000000, SelectMode.SelectRead)
			+	"\nPollW:" + server.Poll(1000000, SelectMode.SelectWrite)
			//+	"\nPollE:" + server.Poll(1000000, SelectMode.SelectError)
			+	"\n******************************"
		).Dump();
		
		server.Receive(inBuf);
		
		for(int i = 0; i < inBuf.Length; i++)
		{
			if(inBuf[i] != 0)
			{
				endBuf.Add(inBuf[i]);
				//Encoding.UTF8.GetString(endBuf.ToArray()).Dump();
			}
		}
		
		//inBuf.Dump();
		
		//Encoding.UTF8.GetString(inBuf).Dump();
	}
	else
	{
		bool endListen = true;
		
		for(int i = 0; i < 100; i++)
		{
			Thread.Sleep(50);
			if(server.Available > 0)
			{
				endListen = false;
				break;
			}
		}
		
		if(endListen == true)
			break;
	}
}

Encoding.UTF8.GetString(endBuf.ToArray()).Dump();