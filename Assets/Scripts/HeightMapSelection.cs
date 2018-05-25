using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapSelection : MonoBehaviour {

	public static float scale = .23f;
    //public static float xCoord = 2.91f;
    //public static float yCoord = 1.5f;
    //public static float zCoord = -.83f;
    //public static float xCoord = 1.85f;
    //public static float yCoord = 0.5f;
    //public static float zCoord = -4.93f;
    public static float xCoord = 3f;
    public static float yCoord = 2.2f;
    public static float zCoord = -5f;

    public static Transform[] mapArray;
	public static Transform InstantiateMap(Transform mapPrefab) {
		Transform map = GameObject.Instantiate (mapPrefab) as Transform;

        map.parent = TrackableMonitor.mTrackableBehaviour.transform;
        map.localPosition = new Vector3 (xCoord, yCoord, zCoord);
		map.localRotation = Quaternion.identity;
		map.localScale = new Vector3 (scale, scale, scale);
		map.gameObject.SetActive (true);
		map.Rotate(90f, 0f, 0f);
        Color temp = map.GetComponent<SpriteRenderer>().color;
        temp.a = 0.5f;
        map.GetComponent<SpriteRenderer>().color = temp;
		return map;
	}
    //public static void updateCoord()
    //{
    //    yCoord = 2f;
    //    zCoord -= 0.1f;
    //}
}
