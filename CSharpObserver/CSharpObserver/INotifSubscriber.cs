namespace CSharpObserver
{
    public interface INotifSubscriber
    {
        void HandleNotification(object obj, string name);
    }
}
