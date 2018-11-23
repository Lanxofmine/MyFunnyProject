using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        private static IPAddress ipAddress = IPAddress.Any;
        private const int PORT = 51388;
        static void Main(string[] args)
        {
            TcpListener tcpServer = new TcpListener(ipAddress, PORT);
            tcpServer.Start();
            Console.WriteLine("等待连接...");
            TcpClient client = tcpServer.AcceptTcpClient();
            Console.WriteLine("连接成功");
            NetworkStream reciveStream = client.GetStream();
            while (client.IsOnline())
            {
                byte[] buffer = new byte[8192];
                int msgSize;
                try
                {
                    lock (reciveStream)
                    {
                        msgSize = reciveStream.Read(buffer, 0, 8192);
                    }
                    if (msgSize == 0)
                        return;
                    string msg = Encoding.Default.GetString(buffer);
                    msg = msg.Replace("\0", "").Trim();
                    Console.WriteLine("客户端："+msg);
                    Console.WriteLine("请回复<按Enter键发送...>");
                    string input = Console.ReadLine();
                    Console.WriteLine("服务器：" + input);
                    byte[] buffers = Encoding.Default.GetBytes(input.Trim());
                    reciveStream.Write(buffers, 0, buffers.Length);
                }
                catch(Exception ex)
                {

                    Console.WriteLine("已断开"+ex.Message);
                    tcpServer.Stop();
                    Main(args);
                }
            }
            Console.ReadKey();
        }
    }
    public static class TcpClientEx
    {
        public static bool IsOnline(this TcpClient c)
        {
            return !((c.Client.Poll(1000, SelectMode.SelectRead) && (c.Client.Available == 0)) || !c.Client.Connected);
        }
    }
}
