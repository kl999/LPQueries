<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.NetworkInformation</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    bool listen = true;
    
    Task.Run(() =>
    {
        string ipStr = "localhost";
        
        using (TcpClient client = new TcpClient() { })
        {
            client.Connect(ipStr, 9080);
        
            using (NetworkStream ns = client.GetStream())
            {
                ns.ReadTimeout = 5000;
                
                var buf = readMsg(ns);
                
                Console.WriteLine(Encoding.UTF8.GetString(buf));
                
                listen = false;
            }
        }
    });
    
    Task.Run(() =>
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 9080);
        listener.Start();
        Console.WriteLine("---START SERVER---");
    
        //for (listen = true; listen;)
            using (TcpClient c = listener.AcceptTcpClient())
            using (NetworkStream ns = c.GetStream())
            {
                writeMsg(ns, Encoding.UTF8.GetBytes("Hello World!"));
            }
    });
}

byte[] read(NetworkStream ns, int len)
{
    var buf = new byte[len];
    
    var offset = 0;
    
    for(;;)
    {
        var retlen = ns.Read(buf, offset, len);
        
        len = len - retlen;
        
        offset = offset + len;
        
        if(len == 0) return buf;
    }
}

byte[] readMsg(NetworkStream ns)
{
    var buf = read(ns, 4);
    
    var msglen = BitConverter.ToInt32(buf, 0).Dump();
    
    return read(ns, msglen);
}

void writeMsg(NetworkStream ns, byte[] buf)
{
    buf = BitConverter.GetBytes(buf.Length).Concat(buf).ToArray();
    
    ns.Write(buf, 0, buf.Length);
}