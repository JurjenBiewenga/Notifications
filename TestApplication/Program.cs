using System;
using System.Threading.Tasks;
using AvaloniaNotifications;
using Sprache;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationManager nm = new NotificationManager();
            while (true)
            {
                if (Console.ReadKey().KeyChar != '\0')
                {
                    lock (nm.notifications_lock)
                    {
                        nm.notifications.Enqueue("Test");
                    }
                }
            }
        }
    }
}