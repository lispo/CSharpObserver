using System.Collections;
using System.Collections.Generic;

namespace CSharpObserver
{
    public class NotificationsList
    {
        private List<string> _notifications;

        private static NotificationsList _instance;

        public const string Collide = "COLLIDE";
        //public const string DEAD = "DEAD";
        //public const string FINISH = "FINISH";

        private NotificationsList()
        {
            _notifications = new List<string>();
            AddNotifications();
        }

        public static NotificationsList Init()
        {
            if (_instance == null)
                _instance = new NotificationsList();

            return _instance;
        }

        private void AddNotifications()
        {
            _notifications.Add(Collide);
            //_notifications.Add(DEAD);
            //_notifications.Add(FINISH);
        }

        public List<string> GetList()
        {
            return _notifications;
        }
    }
}
