// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Transform cameraReferenceTransform;
	public Transform CameraReferenceTransform => cameraReferenceTransform;
	
	[SerializeField] private PlayerController playerController;
}
