﻿//==================================================
//
//  Created by Atqa
//
//==================================================

using UnityEngine;


public abstract class ResourcesSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load<T>(typeof(T).Name);
			}
			return instance;
		}
	}
}

