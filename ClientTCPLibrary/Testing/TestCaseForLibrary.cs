using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ClientTCPLibrary.FileWork;
using ClientTCPLibrary;
using ServerTCPLibrary;
using ServerTCPLibrary.SLAYMethods;
using ServerTCPLibrary.WorkWithDate;


namespace ClientTCPLibrary.Testing
{
    /// <summary>
    /// Class for testing ClientTCPLibrary and ServerTCPLibrary
    /// </summary>
    [TestFixture]
    class TestCaseForLibrary
    {
        /// <summary>
        /// TestCase for read main matrix
        /// </summary>
        [TestCase]
        public void TestMethodReadMainMatrix()
        {
            TextFile textFile = new TextFile();
            var res = textFile.ReadMainMatrix(@"D:\AllTasks\task4\myTxtA.txt");
            
            string str = "    2,000   4,000  3,000  \r\n    1,000   1,000  -2,000  \r\n    4,000   -2,000  3,000  \r\n";
            Assert.AreEqual(res, str);
        }

        /// <summary>
        /// TestCase for read vector
        /// </summary>
        [TestCase]
        public void TestMethodReadVector()
        {
            TextFile textFile = new TextFile();
            var res = textFile.ReadVector(@"D:\AllTasks\task4\myTxtB.txt");
            
            string str = "   -6,000\r\n    9,000\r\n    12,000\r\n";
            Assert.AreEqual(res, str);
        }
        /// <summary>
        /// TestCase for send message on server
        /// </summary>
        [TestCase]
        public void TestMethodSendMessage()
        {
            TextFile textFile = new TextFile();
            var res = textFile.SendMessage(@"D:\AllTasks\task4\myTxtA.txt", @"D:\AllTasks\task4\myTxtB.txt");
            string str = "    2,000   4,000  3,000  \r\n    1,000   1,000  -2,000  \r\n    4,000   -2,000  3,000  \r\n   -6,000\r\n    9,000\r\n    12,000\r\n";
            Assert.AreEqual(res, str);
        }
        /// <summary>
        /// TestCase for create main matrix
        /// </summary>
        [TestCase]
        public void TestMethodCreateMainMatrix()
        {
            TextFile textFile = new TextFile();
            DataProcess dataProcess = new DataProcess();
            
            double[,] res = new double[3, 3] { { 2.0, 4.0, 3.0 },{ 1.0, 1.0, -2.0 },{ 4.0, -2.0, 3.0} };
            Assert.AreEqual(res[0, 0], dataProcess.ReadMainMatrix(textFile.ReadMainMatrix(@"D:\AllTasks\task4\myTxtA.txt"))[0,0]);
        }
        /// <summary>
        /// TestCase for create vector
        /// </summary>
        [TestCase]
        public void TestMethodCreateVector()
        {
            TextFile textFile = new TextFile();
            DataProcess dataProcess = new DataProcess();
            
            double[] res = new double[3] { -6.0, 9.0, 12.0};
            Assert.AreEqual(res[0], dataProcess.ReadVector(textFile.ReadMainMatrix(@"D:\AllTasks\task4\myTxtB.txt"))[0]);
        }
        /// <summary>
        /// TestCase for get date
        /// </summary>
        [TestCase]
        public void TestMethodGetDate()
        {
            TextFile textFile = new TextFile();
            DataProcess dataProcess = new DataProcess();
            dataProcess.GetDate(textFile.SendMessage(@"D:\AllTasks\task4\myTxtA.txt", @"D:\AllTasks\task4\myTxtB.txt"),out double[,] a, out double[] b);
            double[] res = new double[3] { -6.0, 9.0, 12.0};
            double[,] res1 = new double[3, 3] { { 2.0, 4.0, 3.0 }, { 1.0, 1.0, -2.0 }, { 4.0, -2.0, 3.0 } };

            Assert.AreEqual(res[0], b[0]);
            Assert.AreEqual(res1[0,0], a[0,0]);
        }
        /// <summary>
        /// TestCase for SLAY method Gauss
        /// </summary>
        [TestCase]
        public void TestMethodGaussianSolution()
        {
            TextFile textFile = new TextFile();
            DataProcess dataProcess = new DataProcess();
            dataProcess.GetDate(textFile.SendMessage(@"D:\AllTasks\task4\test1A.txt", @"D:\AllTasks\task4\test1B.txt"),out double[,] a, out double[] b);
            GaussianMethod gaussian = new GaussianMethod(a.GetLength(0), b.Length);
            var res = gaussian.GaussianSolution(a,b);
            double[] res1 = new double[10];
            double[] myRes = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 1.8, 0.0 }; 
            for(int i = 0; i < 10; i++)
            {
                res1[i] = Math.Round(res[i], 3);
            }

            Assert.AreEqual(res1, myRes);
        }
        /// <summary>
        /// TestCase for SLAY method Gauss
        /// </summary>
        /*[TestCase]
        public void TestMethodClientAndServer1()
        {
            int res = 0;
            void UserInfoHandler()
            {
                //Console.WriteLine("Данные отправлены!\n");
                res++;

            }
            Server server = new Server();
            server.ServerData(5, UserInfoHandler);
            
            Client client = new Client();
            client.ClientAnswer(@"D:\AllTasks\task4\test1A.txt", @"D:\AllTasks\task4\test1B.txt", UserInfoHandler);

            
            
            Assert.AreEqual(res, 2);
        }*/
    }
}
