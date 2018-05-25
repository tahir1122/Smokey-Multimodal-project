using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.VR.WSA.Input;

public class HandsManager : MonoBehaviour {

    public static bool HandDetected
    {
        get;
        private set;
    }
    public static GameObject FocusedGameObject { get; private set; }

    void Awake()
    {
        InteractionManager.SourceDetected += InteractionManager_SourceDetected;
        InteractionManager.SourceLost += InteractionManager_SourceLost;
        InteractionManager.SourcePressed += InteractionManager_SourcePressed;
        InteractionManager.SourceReleased += InteractionManager_SourceReleased;
    }

    private void InteractionManager_SourceDetected(InteractionSourceState hand)
    {
        HandDetected = true;
    }
    private void InteractionManager_SourceLost(InteractionSourceState hand)
    {
        HandDetected = false;
        FocusedGameObject = null;
    }
    private void InteractionManager_SourcePressed(InteractionSourceState hand)
    {
        if (GazeManager.Instance.HitObject != null)
        {
            FocusedGameObject = GazeManager.Instance.HitObject;
        }
    }

    private void InteractionManager_SourceReleased(InteractionSourceState hand)
    {
        FocusedGameObject = null;
    }
    void OnDestroy()
    {
        InteractionManager.SourceDetected -= InteractionManager_SourceDetected;
        InteractionManager.SourceLost -= InteractionManager_SourceLost;
        
        InteractionManager.SourceReleased -= InteractionManager_SourceReleased;
        InteractionManager.SourcePressed -= InteractionManager_SourcePressed;
    }

}
