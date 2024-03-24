// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;


public class MainResources : ResourcesSingleton<MainResources>
{
	[Header("Prefabs")]
	public GameObject playerPrefab;
	
	[Header("Layer Masks")]
    public LayerMask groundLayerMask;
}
