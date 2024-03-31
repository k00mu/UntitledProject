// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;


public enum PlaySpaceType
{
    General,
    UI,
    World,
}

public class PlaySpace : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform generalTransform;
    [SerializeField] private Transform uiTransform;
    [SerializeField] private Transform worldTransform;
 
    [Header("Cameras")]
    [SerializeField] private Camera cameraBrain;
    [SerializeField] private CameraManager cameraManager;

    [Header("Players")]
    private Player activePlayer;
    public Player ActivePlayer => activePlayer;
    
    public Action<Vector3> OnClick;



    private void Start()
    {
        Initialize();
    }
    
    
    /// <summary>
    /// Initializes the PlaySpace.
    /// </summary>
    private void Initialize()
    {
        activePlayer = Instantiate(MainResources.Instance.playerPrefab).GetComponent<Player>();
        // add to camera manager target group
        cameraManager.AddTarget(activePlayer.CameraReferenceTransform);
        
        AddToPlaySpace(activePlayer.transform, PlaySpaceType.World);
    }


    private void Update()
    {
        ProcessTouchInput();
        ProcessMouseInput();
    }
    
    
    /// <summary>
    /// Processes touch input from the user.
    /// </summary>
    private void ProcessTouchInput()
    {
        if (Input.touchCount <= 0) return;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended) continue;

            HandleTouchInput(touch.fingerId);
        }
    }

    
    /// <summary>
    /// Handles touch input for a specific finger.
    /// </summary>
    /// <param name="_fingerId">The ID of the finger.</param>
    private void HandleTouchInput(int _fingerId)
    {
        OnClick?.Invoke(MouseWorld.GetPosition(_fingerId));
    }

    
    /// <summary>
    /// Processes mouse input by checking if the left mouse button is pressed down. If it is, it calls the HandleMouseInput method.
    /// </summary>
    private void ProcessMouseInput()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        HandleMouseInput();
    }


    /// <summary>
    /// Handles the mouse input by invoking the onClick event with the position of the mouse in world space.
    /// </summary>
    private void HandleMouseInput()
    {
        OnClick?.Invoke(MouseWorld.GetPosition());
    }


    public void AddToPlaySpace(Transform _transform, PlaySpaceType _type)
    {
        switch (_type)
        {
            case PlaySpaceType.General:
                _transform.SetParent(generalTransform);
                break;
            case PlaySpaceType.UI:
                _transform.SetParent(uiTransform);
                break;
            case PlaySpaceType.World:
                _transform.SetParent(worldTransform);
                break;
        }
    }
    
    
    public Transform GetPlaySpace(PlaySpaceType _type)
    {
        switch (_type)
        {
            case PlaySpaceType.General:
                return generalTransform;
            case PlaySpaceType.UI:
                return uiTransform;
            case PlaySpaceType.World:
                return worldTransform;
            default:
                throw new ArgumentOutOfRangeException(nameof(_type), _type, null);
        }
    }


    #region OnValidate

    #if UNITY_EDITOR
    
    private void OnValidate()
    {
        // validate helper checks
        ValidateHelper.CheckNull(generalTransform, nameof(generalTransform), nameof(PlaySpace));
        ValidateHelper.CheckNull(uiTransform, nameof(uiTransform), nameof(PlaySpace));
        ValidateHelper.CheckNull(worldTransform, nameof(worldTransform), nameof(PlaySpace));
        ValidateHelper.CheckNull(cameraBrain, nameof(cameraBrain), nameof(PlaySpace));
        ValidateHelper.CheckNull(cameraManager, nameof(cameraManager), nameof(PlaySpace));
    }
    
    #endif

    #endregion
    
}
