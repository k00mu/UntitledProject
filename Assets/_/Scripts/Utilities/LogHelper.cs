// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public static class LogHelper
{
	public static void Log(string _className, string _methodName, string _message) =>
		Debug.Log($"[{_className}.{_methodName}] {_message}");
	
	public static void LogWarning(string _className, string _methodName, string _message) =>
		Debug.LogWarning($"[{_className}.{_methodName}] {_message}");
	
	public static void LogError(string _className, string _methodName, string _message) =>
		Debug.LogError($"[{_className}.{_methodName}] {_message}");
}
