using BoxServer.Behaviours;
using System;

namespace BoxServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Server().InitServer();
            Console.ReadLine();
        }
    }
}
