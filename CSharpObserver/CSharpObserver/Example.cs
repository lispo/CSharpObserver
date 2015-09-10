using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObserver
{
    class Example
    {
        static void Main(string[] args)
        {
            var subscriber = new MySubScriber();
            var notifier = new MyNotifier();
            notifier.SendNotification("Asteroid!!!");
            subscriber.RemoveSubscription();
            notifier.SendNotification("Other Asteroid!!!");
        }
    }

    class MyNotifier
    {
        private NotificationManager _notificationManager;

        public void SendNotification(string message)
        {
            if(_notificationManager == null)
                _notificationManager = NotificationManager.GetInstance();
            _notificationManager.SendNotification(NotificationsList.Collide, message);
        }
    }

    class MySubScriber : INotifSubscriber
    {
        private readonly NotificationManager _notificationManager;
        public MySubScriber()
        {
            _notificationManager = NotificationManager.GetInstance();
            _notificationManager.RegisterSubscriber(this, NotificationsList.Collide);
        }

        public void HandleNotification(object obj, string name)
        {
            switch (name)
            {
                case NotificationsList.Collide:
                    Console.WriteLine("Collide: " + obj);
                break;
            }
        }

        public void RemoveSubscription()
        {
            _notificationManager.RemoveSubscriber(this, NotificationsList.Collide);
        }
    }
}
