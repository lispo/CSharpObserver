using System.Collections;

namespace CSharpObserver
{
    public delegate void NotifyDelegate(object data, string name);

    public class Notifier
    {
        public event NotifyDelegate Notif;

        public void SendNotification(object obj, string name)
        {
            if (Notif != null) Notif(obj, name);
        }
    }
}
