﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ServerTCPLibrary.SLAYMethods;
using ClientTCPLibrary.FileWork;

namespace ServerTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);

            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();
                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }                    

                while (listener.Available > 0);
                Console.WriteLine(data.ToString());

                TextFile text = new TextFile();
                text.GetDate(data.ToString(), out double[,] a, out double[] b);
                GaussianMethod gaussianMethod = new GaussianMethod(a.GetLength(0), b.Length);
                var x = gaussianMethod.GaussianSolution(a,b);
                StringBuilder answ = new StringBuilder();
                for (int i = 0; i < x.Length - 1; i++)
                {
                    answ.Append(x[i] + "\n");                   
                }
                listener.Send(Encoding.UTF8.GetBytes(answ.ToString()));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}