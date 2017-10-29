using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Input;
using Avalonia.Threading;
using Avalonia.Reactive;

namespace AvaloniaNotifications
{
    public class NotificationManager
    {
        public static AppBuilder app;
        public Queue<string> notifications = new Queue<string>();
        public Object notifications_lock = new object();

        public NotificationManager()
        {
            Thread t = new Thread(Start);
            t.Start();
//            Start();
        }

        public void Start()
        {
            Application application = new Application();
            app = AppBuilder.Configure(application).UsePlatformDetect();
            app.SetupWithoutStarting();
            application.Run(new Closeable(notifications_lock, notifications));
        }
    }

    public class Closeable : ICloseable
    {
        public event EventHandler Closed;

        public Closeable(Object notificationsLock, Queue<string> notifications)
        {
            Dispatcher.UIThread.InvokeTaskAsync(()=>Test(notificationsLock, notifications), DispatcherPriority.Background);
//            Test(notificationsLock, notifications);
        }

        public async void Test(Object notificationsLock, Queue<string> notifications)
        {
            while (true)
            {
                lock (notificationsLock)
                {
                    if (notifications.Count > 0)
                    {
                        MainWindow window = new MainWindow(new Notification());
                        window.Show();
                        Console.WriteLine(notifications.Dequeue());
                    }
                }
                await Task.Delay(1000);
            }
        }
    }
}