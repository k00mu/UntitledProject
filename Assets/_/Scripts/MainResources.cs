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



    #region OnValidate
    
    #if UNITY_EDITOR

	private void OnValidate()
	{
		// validate helper checks
		ValidateHelper.CheckNull(playerPrefab, nameof(playerPrefab), nameof(MainResources));
		ValidateHelper.CheckZero(groundLayerMask, nameof(groundLayerMask), nameof(MainResources));
	}

	#endif

    #endregion
    
}
