<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var dc = new DumpContainer();
dc.Dump();

int len = 65536;

Socket[] socks = new Socket[len];

DateTime lsh = DateTime.Now;

TimeSpan ts = new TimeSpan(1000);

for(int i = 0; i < len; i++)
{
    IPEndPoint extPoint =
        //new IPEndPoint(IPAddress.Parse("10.17.130.82"), 11037)
        new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8088)
        ;
    
    socks[i] = new Socket(
    	AddressFamily.InterNetwork,
    	SocketType.Stream,
    	ProtocolType.Tcp);
    
    socks[i].ReceiveTimeout = 5000;
    
    //server.Send(Encoding.UTF8.GetBytes(Console.ReadLine()));
    
    /*server.SetSocketOption(
    	SocketOptionLevel.Tcp,
    	SocketOptionName.KeepAlive,
    	true);*/
    
    socks[i].Connect(extPoint);
    
    if(DateTime.Now - lsh > ts)
    {
        dc.Content = $"{lsh = DateTime.Now}; i: {i}; sock: {(socks[i].LocalEndPoint as IPEndPoint).Port}";
    }
    
    //sock.Dump();
    
    //Thread.Sleep(1);
    
    //socks[i].Close();
}