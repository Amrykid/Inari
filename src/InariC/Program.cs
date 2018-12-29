using Inari;
using System;
using System.Reflection;
using System.Security;

namespace InariC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Inari for Kitsu.IO";

            Console.WriteLine("Inari for Kitsu.IO (v{0})", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            RunAsync().Wait();
        }

        private static async System.Threading.Tasks.Task RunAsync()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            Console.CursorVisible = false;
            string password = Console.ReadLine();
            Console.CursorVisible = true;

            using (KitsuSession session = await KitsuSession.BeginSession(username, password))
            {

            }
        }
    }
}
