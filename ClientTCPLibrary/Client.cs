using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientTCPLibrary.FileWork;
using ServerTCPLibrary.DelegateAndEvent;

namespace ClientTCPLibrary
{
    /// <summary>
    /// Class for client
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Ip
        /// </summary>
        const string ip = "127.0.0.1";
        /// <summary>
        /// Port
        /// </summary>
        const int port = 8080;

        /// <summary>
        /// Method for sending data from client to server
        /// </summary>
        /// <param name="pathA">Path of file with main matrix</param>
        /// <param name="pathB">Path of file with vector</param>
        /// <param name="InfoHandler">event handler</param>
        /// <returns>string with data</returns>
        public string ClientAnswer(string pathA, string pathB, SLAY InfoHandler) 
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TextFile textFile = new TextFile();
            string message = textFile.SendMessage(pathA, pathB);
            var data = Encoding.UTF8.GetBytes(message);
            MyEvent myEvent = new MyEvent();
            myEvent.SLAYEvent += () => InfoHandler();
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
