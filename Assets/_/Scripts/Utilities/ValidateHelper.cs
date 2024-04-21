// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public static class ValidateHelper
{
	
	// TODO: fix later
	public static bool CheckNullThenAssign<T>(T _object, GameObject _gameObject, string _objectName, string _className, out T _assignedObject) where T : Component
	{
		_assignedObject = null;
		if (_gameObject.TryGetComponent(out T _component))
		{
			_assignedObject = _component;
			return true;
		}

		if (_assignedObject == null)
		{
			Debug.LogWarning(
				$"[{_className}:ValidateHelper] {_objectName} component not found. Adding {_objectName} component on {_gameObject.name} GameObject");
			_assignedObject = _gameObject.AddComponent<T>();
			return true;
		}
		
		return false;
	}
	
	public static bool CheckNull<T>(T _object, string _objectName, string _className) where T : Object
	{
		if (_object == null)
		{
			Debug.LogError($"[{_className}:ValidateHelper] {_objectName} is null. Please assign a {typeof(T)} on {_className}.{_objectName} asset");
			return false;
		}

		return true;
	}
	
	public static bool CheckEmptyString(string _string, string _stringName, string _className)
	{
		if (string.IsNullOrEmpty(_string))
		{
			Debug.LogError($"[{_className}:ValidateHelper] {_stringName} is empty. Please assign a value on {_className}.{_stringName} asset");
			return false;
		}

		return true;
	}
	
	public static bool CheckZero(float _value, string _valueName, string _className)
	{
		if (_value == 0)
		{
			Debug.LogError($"[{_className}:ValidateHelper] {_valueName} is zero. Please assign a value on {_className}.{_valueName} asset");
			return false;
		}

		return true;
	}
	
	public static bool CheckZero(int _value, string _valueName, string _className)
	{
		if (_value == 0)
		{
			Debug.LogError($"[{_className}:ValidateHelper] {_valueName} is zero. Please assign a value on {_className}.{_valueName} asset");
			return false;
		}

		return true;
	}
	
}
