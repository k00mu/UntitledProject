// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public class GameManager : MonoBehaviourSingletonDDOL<GameManager>
{
	private PlaySpace activePlaySpace;
	public PlaySpace ActivePlaySpace => activePlaySpace;


	private void Start()
	{
		activePlaySpace = Instantiate(MainResources.Instance.playSpacePrefabs[0].GetComponent<PlaySpace>());
	}
	

	public void SetActivePlaySpace(PlaySpace _playSpace)
	{
		activePlaySpace = _playSpace;
		// enable the new play space
	}
}
