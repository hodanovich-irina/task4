using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClientTCPLibrary;
using ClientTCPLibrary.FileWork;

namespace ClientTCP
{
    class Program
    {
        private static void UserInfoHandler()
        {
            Console.WriteLine("Данные отправлены!\n");
            Console.ReadLine();

        }
        static void Main(string[] args)
        {
            Client client = new Client();
            Console.WriteLine(client.ClientAnswer("test1A.txt", "test1B.txt", UserInfoHandler));

            Console.ReadLine();
        }
    }
}
