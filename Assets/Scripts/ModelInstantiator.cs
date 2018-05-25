using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInstantiator : MonoBehaviour {

	public string dataSet;
	public float scale = .013f;
	public Transform[] dataPoints;
	public string color;
    public string name1;

	public void InstantiateDataPoints(List<double> longitude, List<double> lattitude, Transform prefab)	{
		dataPoints = new Transform[longitude.Count];

		for (int i = 0; i < longitude.Count; i++)
		{
			dataPoints[i] = InstantiateDataPoint(longitude[i], lattitude[i], prefab);
        }
	}
	
	public Transform InstantiateDataPoint(double longitude, double lattitude, Transform prefab)
	{
		Transform dataTrf = Instantiate (prefab) as Transform;
        dataTrf.parent = Subspaces.focus25;
        dataTrf.localPosition = new Vector3 ((float)longitude, (float)lattitude*1.34f-0.04f, -2f );
        dataTrf.localRotation = Quaternion.identity;
        dataTrf.localScale = new Vector3 (scale, scale, 0.4f);
		dataTrf.gameObject.SetActive (true);
        //dataTrf.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        Material newMaterial = new Material(Shader.Find("VertexLit"));
        newMaterial.color = findcolor(color);
        dataTrf.GetComponent<Renderer>().material = newMaterial;
        //dataTrf.name = SmokeyController.nodeCount.ToString();
        dataTrf.name = name1 + "_" + color + "_(large display)";
        dataTrf.GetComponent<PrefabID>().id = SmokeyController.nodeCount;
        SmokeyController.nodeCount++;
        SmokeyController.eachSpecieCount++;
        SmokeyController.allHabitats.Add(dataTrf.gameObject);
		return dataTrf;
	}

    public static void hideAll() {
        foreach(var item in SmokeyController.allHabitats)
        {
            item.gameObject.SetActive(false);
        }
        foreach(var item in SmokeyController.LayeredHabitats)
        {
            item.gameObject.SetActive(false);
        }
    }

	//public Transform InstantiateGraphNode(double longitude, double lattitude, Transform prefab)
	//{
	//	Transform dataTrf = GameObject.Instantiate (prefab) as Transform;
	//	dataTrf.parent = TrackableMonitor.mTrackableBehaviour.transform;
	//	dataTrf.localPosition = new Vector3 ((float)longitude, 0f, (float)lattitude);
	//	dataTrf.localRotation = Quaternion.identity;
	//	dataTrf.localScale = new Vector3 (0f, 0f, 0f);
	//	dataTrf.gameObject.SetActive (true);
	//	return dataTrf;
	//}


    public static Color findcolor(string color)
    {
        Color outt = Color.white;
        switch (color)
        {
            case "red":
                outt = Color.red;
                break;
            case "blue":
                outt = Color.blue;
                break;
            case "green":
                outt = Color.green;
                break;
            case "magenta":
                outt = Color.magenta;
                break;
            case "yellow":
                outt = Color.yellow;
                break;
            case "cyan":
                outt = Color.cyan;
                break;
            case "black":
                outt = Color.red;           /////////////////////////////////////////////////////////////////////////////////////////
                break;
            case "gray":
                outt = Color.gray;
                break;
            case "orange":
                outt = new Color(1, 0.15f, 0);
                break;
            case "purple":
                outt = new Color(1f, 0.2f, 0.45f);
                break;
            case "white":
                outt = Color.white;
                break;
        }
        return outt;
    }
}

