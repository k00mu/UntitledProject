﻿// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T Instance { get; private set; }
	
	
	
	protected virtual void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this as T;
	}
}
