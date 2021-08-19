using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientTCPLibrary.FileWork;
using ServerTCPLibrary.SLAYMethods;

namespace ClientTCPLibrary
{
    public class Client
    {
        public string ClientAnswer(string pathA, string pathB, UI UserInfoHandler) 
        {
            const string ip = "127.0.0.1";
            const int port = 8080;
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TextFile textFile = new TextFile();
            string message = textFile.SendMessage(pathA, pathB);
            var data = Encoding.UTF8.GetBytes(message);
            MyEvent myEvent = new MyEvent();
            myEvent.SLAYEvent += UserInfoHandler;
            myEvent.OnSLAYEvent();
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);
            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();
            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
            return answer.ToString();
        }
    }
}
