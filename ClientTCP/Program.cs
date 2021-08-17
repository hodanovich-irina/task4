using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientTCPLibrary;
using ClientTCPLibrary.FileWork;
using ServerTCPLibrary.SLAYMethods;

namespace ClientTCP
{
    class Program
    {
        static void Main(string[] args)
        {
            //TextFile text = new TextFile();
            //var a = text.ReadMainMatrix(data.ToString());
            //var z = text.SendVector("test1B.txt");
            //var b = text.ReadVector(z);
            //text.GetDate(text.SendMessage("test1A.txt", "test1B.txt"), out double[,] a, out double[] b);
            //GaussianMethod gaussianMethod = new GaussianMethod(a.GetLength(0), b.Length);
            //var x = gaussianMethod.GaussianSolution(a, b);
            //Console.WriteLine();
            //for (int i = 0; i < x.Length - 1; i++)
                //Console.WriteLine(x[i]);
                //TextFile textFile = new TextFile();

                /*textFile.ReadMainMatrix("test1A.txt");
                textFile.SendMessage("test1A.txt", "test1B.txt");
                string str = textFile.SendMessage("test1A.txt", "test1B.txt");
                textFile.GetDate(str, out double[,] a, out double[] B);
                double[,] A = a;
                double[] b = B;*/
                //string[] A1 = textFile.SendMainMatrix().Split('\n');
                //string[] A2 = textFile.SendVector().Split('\n');
                //textFile.GetDate(textFile.SendMessage("test1A.txt", "test1B.txt"),out double[,]  a,out double[]  b);

                //Console.WriteLine(textFile.SendMessage("testMy2.txt", "testMy1.txt"));
                //for(int i = 0; i < a.GetLength(0) - 1; i++)
                //Console.WriteLine(a[i,0]);
                //Console.WriteLine(b[48]);

                //Console.WriteLine(strAll);
                //for (int i = 1; i < str1.Length - 1; i++)
                //{
                //str += str1[i] + " " + str2[i] + "\n";
                //}

                //Console.WriteLine(b.Length);
                //GaussianMethod method = new GaussianMethod(A.GetLength(0) , A.GetLength(1));

                //Console.WriteLine(A.GetLength(0) + " " + A.GetLength(1));
                //for(int i = 0; i < str.Length - 1; i++)
                // Console.WriteLine(str);
                //double[] x = method.GaussianSolution(A, b);
                //GaussianMethod gausMethod = new GaussianMethod(str);
                //double[] x = gausMethod.GaussianSolution(A, b);
                /*for (int i = 0; i < x.Length - 1; i++)
                    Console.WriteLine(x[i]);
                Console.ReadLine();*/
                //GaussianMethod.GausMethod gausMethod = new GaussianMethod.GausMethod(3,3);
                //gausMethod.Matrix = A;
                //gausMethod.RightPart = b;
                //gausMethod.Matrix = new double[3][];
                //gausMethod.Matrix[0] = new double[3] { 2.0, 4.0, 3.0 };
                //gausMethod.Matrix[1] = new double[3] { 1.0, 1.0, -2.0 };
                //gausMethod.Matrix[2] = new double[3] { 4.0, -2.0, 3.0 };
                //gausMethod.RightPart = new double[3] { -6.0, 9.0, 12.0 };
                //Console.WriteLine(b[0]);
                //for (int i = 0; i < A.GetLength(1); i++)
                //Console.Write(A[0, i]);
                //Console.WriteLine(x[0]);
                //x[0] = b[b.Length - 1];

                //for (int i = 0; i < A.GetLength(0); i++)
                //{
                //for (int j = 0; j < A.GetLength(1); j++)
                //{
                //a[i, j] = Convert.ToDouble(row[j]);
                //Console.Write(" {0}", A[0, j]);
                //}
                //Console.WriteLine();
                //}
                //Console.ReadLine();
            const string ip = "127.0.0.1";
            const int port = 8080;
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Read a message:");
            TextFile textFile = new TextFile();
            var message = textFile.SendMessage("test1A.txt", "test1B.txt");

            var data = Encoding.UTF8.GetBytes(message);

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

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}
