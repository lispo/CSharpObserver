using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationsList
{
	private List<string> _notifications;
	
	private static NotificationsList _instance;

    //public const string COLLIDE = "COLLIDE";
    //public const string DEAD = "DEAD";
    //public const string FINISH = "FINISH";

	private NotificationsList()
	{
		_notifications = new List<string>();
		AddNotifications();
	}

	public static NotificationsList init()
	{
		if(_instance == null)
			_instance = new NotificationsList();

			return _instance;
	}

	private void AddNotifications()
	{
        //_notifications.Add(COLLIDE);
        //_notifications.Add(DEAD);
        //_notifications.Add(FINISH);
	}

	public List<string> getList()
	{
		return _notifications;
	}


}
