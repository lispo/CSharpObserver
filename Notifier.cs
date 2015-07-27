using UnityEngine;
using System.Collections;

public delegate void NotifyDelegate(object data, string name); 

public class Notifier 
{
	public event NotifyDelegate notif;

	public Notifier()
	{
	}

	public void SendNotification(object obj, string name)
	{
		notif(obj, name);
	}
}
