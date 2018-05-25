using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSubspaces : MonoBehaviour {
    public static List<Transform> all = new List<Transform>();
    public static void myImage(Transform blackwhite)
    {
        Transform image1 = GameObject.Instantiate(blackwhite) as Transform;         ///back one
        image1.parent = TrackableMonitor.mTrackableBehaviour.transform;
        image1.localPosition = new Vector3(10.03f, -10.18f, -1.48f);
        image1.localRotation = Quaternion.Euler(90, 0, 0);
        image1.localScale = new Vector3(2.473772f, 2.026573f, 0.1f);
        image1.gameObject.SetActive(true);
        all.Add(image1);

        Transform image2 = GameObject.Instantiate(blackwhite) as Transform;
        image2.parent = TrackableMonitor.mTrackableBehaviour.transform;             // left one
        image2.localPosition = new Vector3(-1.13f, 9.1f, -1.48f);
        image2.localRotation = Quaternion.Euler(0, -90, -90);
        image2.localScale = new Vector3(4.276354f, 2.026573f, 0.1f);
        image2.gameObject.SetActive(true);
        all.Add(image2);

        Transform image3 = GameObject.Instantiate(blackwhite) as Transform;
        image3.parent = TrackableMonitor.mTrackableBehaviour.transform;             // right one
        image3.localPosition = new Vector3(21.18f, 9.1f, -1.48f);
        image3.localRotation = Quaternion.Euler(0, -90, -90);
        image3.localScale = new Vector3(4.276354f, 2.026573f, 0.1f);
        image3.gameObject.SetActive(true);
        all.Add(image3);

        Transform image4 = GameObject.Instantiate(blackwhite) as Transform;         ///front one
        image4.parent = TrackableMonitor.mTrackableBehaviour.transform;
        image4.localPosition = new Vector3(10.03f, 28.35f, -1.48f);
        image4.localRotation = Quaternion.Euler(90, 0, 0);
        image4.localScale = new Vector3(2.473772f, 2.026573f, 0.1f);
        image4.gameObject.SetActive(true);
        all.Add(image4);
    }

    public static void show()
    {
        foreach(Transform item in all)
        {
            item.gameObject.SetActive(true);
        }
    }
    public static void hide()
    {
        foreach(Transform item in all)
        {
            item.gameObject.SetActive(false);
        }
    }
}
