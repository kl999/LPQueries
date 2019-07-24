using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace TCPLib
{
    public class MyTCPClient : IDisposable
    {
        private TcpClient client;
        private readonly NetworkStream strm;

        public MyTCPClient(TcpClient client)
        {
            this.client = client;
            strm = client.GetStream();
        }

        public MyTCPClient(string server, int port)
        {
            client = new TcpClient(server, port);
            strm = client.GetStream();
        }

        public void Dispose()
        {
            if(client != null) client.Dispose();
        }

        public void SendMessage(byte[] buf)
        {
            if(!client.Connected) return;

            var combBuf = new List<byte>();

            combBuf.Add((byte)'|');

            combBuf.AddRange(BitConverter.GetBytes(buf.Length));

            combBuf.Add((byte)'|');

            combBuf.AddRange(buf);

            combBuf.Add((byte)'|');

            strm.Write(combBuf.ToArray(), 0, combBuf.Count);
        }

        public Message ReceveMessage()
        {
            if(!client.Connected) return null;

            int bt = strm.ReadByte();
            if (bt != (byte)'|') throw new IOException("Incorrect message start!");

            var buf = new byte[1024];

            if(strm.Read(buf, 0, 4) < 4) throw new IOException("Incorrect message start!");

            bt = strm.ReadByte();
            if(bt != (byte)'|') throw new IOException("Incorrect message start!");

            var msgLen = BitConverter.ToInt32(buf, 0);

            var msg = new Message();

            for(;msgLen > 0;)
            {
                if(!client.Connected) return null;

                var readCt = strm.Read(buf, 0, msgLen < buf.Length ? msgLen : buf.Length);

                if(readCt < 1) throw new IOException("Incorrect message length!");

                msg.Bytes.AddRange(buf.Take(readCt));

                msgLen -= readCt;
            }

            bt = strm.ReadByte();
            if(bt != (byte)'|') throw new IOException("Incorrect message end!");

            return msg;
        }
    }
}