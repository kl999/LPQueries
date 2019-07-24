using System;
using System.Text;
using System.Threading;
using TCPLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);

            var clt = new MyTCPClient("localhost", 90);

            clt.SendMessage(Encoding.UTF8.GetBytes("Hi!"));

            Console.WriteLine("MessageSent.");

            Console.ReadLine();
        }
    }
}
