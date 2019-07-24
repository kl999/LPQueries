using System;
using System.Text;
using TCPLib;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = new TCPServer(90);
            srv.NewClientEvent += clientConnected;

            Console.WriteLine("Server start.");

            Console.ReadLine();
        }

        private static void clientConnected(object sender, NewClientEventArgs e)
        {
            var clt = e.client;

            var msg = clt.ReceveMessage();

            System.Console.WriteLine($"{DateTime.Now:HH:mm}: {Encoding.UTF8.GetString(msg.Bytes.ToArray())}");
        }
    }
}
