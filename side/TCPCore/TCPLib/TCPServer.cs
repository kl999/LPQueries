using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCPLib
{
    public class TCPServer
    {
        private readonly int port;
        private readonly Thread mainTrd;
        
        private TcpListener lsnr;

        public bool started = true;

        public TCPServer(int port)
        {
            this.port = port;

            lsnr = new TcpListener(IPAddress.Any, port);

            lsnr.Start();

            mainTrd = new Thread(mainTrdRun);
            mainTrd.IsBackground = true;
            mainTrd.Start();
        }

        private async void mainTrdRun()
        {
            while (started)
            {
                TcpClient client = await lsnr.AcceptTcpClientAsync();

                var myClt = new MyTCPClient(client);

                new Thread(() => RaiseNewClientEvent(myClt)).Start();
            }
        }
        
        public delegate void NewClientEventHandler(object sender, NewClientEventArgs e);
        
        public event NewClientEventHandler NewClientEvent;

        protected virtual void RaiseNewClientEvent(MyTCPClient myClt)
        {
            // Raise the event by using the () operator.
            if (NewClientEvent != null)
                NewClientEvent(this, new NewClientEventArgs(myClt));
        }
    }
}