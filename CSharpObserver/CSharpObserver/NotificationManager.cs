using System.Collections;
using System.Collections.Generic;

namespace CSharpObserver
{
    public class NotificationManager
    {
        private static NotificationManager _instance;
        private Dictionary<string, Notifier> _notifiers;

        private NotificationManager()
        {
            _notifiers = new Dictionary<string, Notifier>();
            RegisterNotifications();
        }

        public static NotificationManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NotificationManager();
            }
            return _instance;
        }

        private void RegisterNotifications()
        {
            var notificationsList = NotificationsList.Init();
            List<string> list = notificationsList.GetList();

            for (int i = 0; i < list.Count; i++)
            {
                var notifier = new Notifier();
                _notifiers.Add(list[i], notifier);
            }
        }

        public void SendNotification(string name, object obj)
        {
            _notifiers[name].SendNotification(obj, name);
        }

        public void RegisterSubscriber(INotifSubscriber subscriber, string notifyName)
        {
            _notifiers[notifyName].Notif += subscriber.HandleNotification;
        }

        public void RemoveSubscriber(INotifSubscriber subscriber, string notifyName)
        {
            _notifiers[notifyName].Notif -= subscriber.HandleNotification;
        }
    }
}
