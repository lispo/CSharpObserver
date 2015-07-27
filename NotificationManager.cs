using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NotificationManager
{
	private static NotificationManager _instance;
	private Dictionary<string, Notifier> _notifiers;

	private NotificationManager()
	{
		_notifiers = new Dictionary<string, Notifier>();
		RegisterNotifications();
	}

	public static NotificationManager getInstance()
	{
		if (_instance == null) 
		{
			_instance = new NotificationManager();
		}
		return _instance;
	}

	private void RegisterNotifications()
	{
		var _list = NotificationsList.init();
		List<string> list = _list.getList();

		for(int i = 0; i < list.Count; i++)
		{
			var notifier = new Notifier();
			notifier.notif += new NotifyDelegate(Listener);
			_notifiers.Add(list[i], notifier);
		}
	}

	public void sendNotification(string name ,object obj)
	{
		_notifiers[name].SendNotification(obj, name);
	}

	private void Listener(object obj, string name){} 

	public void RegisterSubscriber(INotifSubscriber subscriber, string notifyName)
	{
		_notifiers[notifyName].notif += new NotifyDelegate(subscriber.handleNotification);
	}

	public void RemoveSubscriber(INotifSubscriber subscriber, string notifyName)
	{
		_notifiers[notifyName].notif -= new NotifyDelegate(subscriber.handleNotification);
	}
}
