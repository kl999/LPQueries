<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

IPEndPoint extPoint = new IPEndPoint(IPAddress.Parse("10.17.129.242"), 80);

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

server.Connect(extPoint);

DateTime startTime = DateTime.Now;

server.Connected.Dump();

server.Send(
	Encoding.UTF8.GetBytes(@"GET / HTTP/1.0
Host: kaspi.kz
User-Agent: Zlopera

")
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