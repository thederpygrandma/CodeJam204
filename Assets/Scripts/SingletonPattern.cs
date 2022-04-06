using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code copied from: https://www.youtube.com/watch?v=Ova7l0UB26U&t=0s
public class SingletonPattern<T> : MonoBehaviour where T : Component
{
	private static T _instance;
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				var objs = FindObjectsOfType(typeof(T)) as T[];
				if (objs.Length > 0)
					_instance = objs[0];
				if (objs.Length > 1)
				{
					Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
				}
				if (_instance == null)
				{
					GameObject obj = new GameObject();
					obj.hideFlags = HideFlags.HideAndDontSave;
					_instance = obj.AddComponent<T>();
				}
			}
			return _instance;
		}
	}
}
