using UnityEngine;
using UnityEngine.VR.WSA.Input;


public class GestureManager : MonoBehaviour
{
        public GestureRecognizer NavigationRecognizer { get; private set; }
        public GestureRecognizer ManipulationRecognizer { get; private set; }

    public static bool IsManipulating = false;

        public static Vector3 ManipulationPosition { get; private set; }

    public static bool IsNavigating = false;

        public static Vector3 NavigationPosition { get; private set; }
    public static GameObject focusedObject;

    void Awake()
    {
        NavigationRecognizer = new GestureRecognizer();
        NavigationRecognizer.SetRecognizableGestures(
                GestureSettings.Tap |
                GestureSettings.NavigationX);

        //NavigationRecognizer.TappedEvent += NavigationRecognizer_TappedEvent;
        //NavigationRecognizer.NavigationStartedEvent += NavigationRecognizer_NavigationStartedEvent;
        //NavigationRecognizer.NavigationUpdatedEvent += NavigationRecognizer_NavigationUpdatedEvent; 
        //NavigationRecognizer.NavigationCompletedEvent += NavigationRecognizer_NavigationCompletedEvent;
        //NavigationRecognizer.NavigationCanceledEvent += NavigationRecognizer_NavigationCanceledEvent;
        //NavigationRecognizer.StartCapturingGestures();


        ManipulationRecognizer = new GestureRecognizer();
        ManipulationRecognizer.SetRecognizableGestures(GestureSettings.ManipulationTranslate);
        
        ManipulationRecognizer.ManipulationStartedEvent += ManipulationRecognizer_ManipulationStartedEvent;
        ManipulationRecognizer.ManipulationUpdatedEvent += ManipulationRecognizer_ManipulationUpdatedEvent;
        ManipulationRecognizer.ManipulationCompletedEvent += ManipulationRecognizer_ManipulationCompletedEvent;
        ManipulationRecognizer.ManipulationCanceledEvent += ManipulationRecognizer_ManipulationCanceledEvent;
        
        ManipulationRecognizer.StartCapturingGestures();
    }

    void OnDestroy()
    {
        //NavigationRecognizer.TappedEvent -= NavigationRecognizer_TappedEvent;
        //NavigationRecognizer.NavigationStartedEvent -= NavigationRecognizer_NavigationStartedEvent;
        //NavigationRecognizer.NavigationUpdatedEvent -= NavigationRecognizer_NavigationUpdatedEvent;
        //NavigationRecognizer.NavigationCompletedEvent -= NavigationRecognizer_NavigationCompletedEvent;
        //NavigationRecognizer.NavigationCanceledEvent -= NavigationRecognizer_NavigationCanceledEvent;


        ManipulationRecognizer.ManipulationStartedEvent -= ManipulationRecognizer_ManipulationStartedEvent;
        ManipulationRecognizer.ManipulationUpdatedEvent -= ManipulationRecognizer_ManipulationUpdatedEvent;
        ManipulationRecognizer.ManipulationCompletedEvent -= ManipulationRecognizer_ManipulationCompletedEvent;
        ManipulationRecognizer.ManipulationCanceledEvent -= ManipulationRecognizer_ManipulationCanceledEvent;
    }

    private void NavigationRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray ray)
    {
        GameObject focusedObject = HandsManager.FocusedGameObject;

        if (focusedObject != null)
        {
            focusedObject.SendMessageUpwards("OnSelect");
        }
    }

    //private void NavigationRecognizer_NavigationStartedEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    //{
    //    IsNavigating = true;
    //    NavigationPosition = relativePosition;
    //}

    //private void NavigationRecognizer_NavigationUpdatedEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    //{
    //    IsNavigating = true;
    //    NavigationPosition = relativePosition;
    //}

    //private void NavigationRecognizer_NavigationCompletedEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    //{
    //    IsNavigating = false;
    //}

    //private void NavigationRecognizer_NavigationCanceledEvent(InteractionSourceKind source, Vector3 relativePosition, Ray ray)
    //{
    //    IsNavigating = false;
    //}


    private void ManipulationRecognizer_ManipulationStartedEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        if (HandsManager.FocusedGameObject != null)
        {
            IsManipulating = true;

            ManipulationPosition = Vector3.zero;

            HandsManager.FocusedGameObject.SendMessageUpwards("PerformManipulationStart", ManipulationPosition);
        }
    }

    private void ManipulationRecognizer_ManipulationUpdatedEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        if (HandsManager.FocusedGameObject != null)
        {
            IsManipulating = true;

            ManipulationPosition = position;

            HandsManager.FocusedGameObject.SendMessageUpwards("PerformManipulationUpdate", position);
            focusedObject = HandsManager.FocusedGameObject;
        }
    }

    private void ManipulationRecognizer_ManipulationCompletedEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        IsManipulating = false;
        focusedObject.GetComponent<GestureActionLayers>().PerformManipulationComplete();
        //HandsManager.FocusedGameObject.SendMessageUpwards("PerformManipulationComplete", position);
        focusedObject = null;
    }

    private void ManipulationRecognizer_ManipulationCanceledEvent(InteractionSourceKind source, Vector3 position, Ray ray)
    {
        IsManipulating = false;
    }
}