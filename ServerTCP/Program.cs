using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ServerTCPLibrary.SLAYMethods;
using ServerTCPLibrary.WorkWithDate;
using ServerTCPLibrary;


namespace ServerTCP
{
    
    class Program
    {
        
        private static void UserInfoHandler()
        {
            Console.WriteLine("Событие вызвано!\n");
            Console.ReadLine();


        }
        static void Main(string[] args)
        {
            Server server = new Server();
            server.ServerData(5, UserInfoHandler);
           
        }
    }
}
