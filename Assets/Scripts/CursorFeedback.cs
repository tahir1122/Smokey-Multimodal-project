using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFeedback : MonoBehaviour {

    [Tooltip("Drag a prefab object to display when a hand is detected.")]
    public GameObject HandDetectedAsset;
    private GameObject handDetectedGameObject;

    [Tooltip("Drag a prefab object to display when a pathing enabled Interactible is detected.")]
    public GameObject PathingDetectedAsset;
    private GameObject pathingDetectedGameObject;

    [Tooltip("Drag a prefab object to parent the feedback assets.")]
    public GameObject FeedbackParent;


    void Awake()
    {
        if (HandDetectedAsset != null)
        {
            handDetectedGameObject = InstantiatePrefab(HandDetectedAsset);
        }
        if (PathingDetectedAsset != null)
        {
            pathingDetectedGameObject = InstantiatePrefab(PathingDetectedAsset);
        }
    }
    private GameObject InstantiatePrefab(GameObject inputPrefab)
    {
        GameObject instantiatedPrefab = null;
        if (inputPrefab != null && FeedbackParent != null)
        {
            instantiatedPrefab = GameObject.Instantiate(inputPrefab);
            instantiatedPrefab.transform.parent = FeedbackParent.transform;
            
            instantiatedPrefab.gameObject.SetActive(false);
        }

        return instantiatedPrefab;
    }

    void Update()
    {
        UpdateHandDetectedState();

        UpdatePathDetectedState();
    }
    private void UpdateHandDetectedState()
    {
        if (handDetectedGameObject == null)
        {
            return;
        }

        handDetectedGameObject.SetActive(HandsManager.HandDetected);
    }

    private void UpdatePathDetectedState()
    {
        if (pathingDetectedGameObject == null)
        {
            return;
        }

        if (HandsManager.FocusedGameObject == null)
        {
            pathingDetectedGameObject.SetActive(false);
            return;
        }
        pathingDetectedGameObject.SetActive(true);
    }
}
