using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredMapping : MonoBehaviour {

    //public static float layerOffset = 0.05f;
    public static float Zoffset = 15f;
    public static List<Transform> layers;
    //public static List<Vector3> lastLocations;
    public static bool layersActive;
    public static float map_posY = 0f;
    public static float scale = 0.4f;
    public static int nodeSize = 0;
    public static Transform dateNode;

    private void Update()
    {
        //if (Input.GetKeyDown("y"))
        //{
        //    print("here");
        //    SmokeyController.makeENVlayer(2);
        //    //SmokeyController.makeENVlayer(3);
        //}
    }

    //public static void BuildLayers_new(Transform node)
    //{
    //    int mapIndex = 0;
    //    for (int i = 5; i < ServerStream.count; i++)
    //    {
    //        foreach (Transform dp in SmokeyController.instantiators[i].dataPoints)
    //        {
    //            if (node != null)
    //            {
    //                Transform dataTrf = GameObject.Instantiate(node) as Transform;
    //                dataTrf.parent = layers[mapIndex];
    //                var pos = dp.localPosition;
    //                Material newMaterial = new Material(Shader.Find("VertexLit"));
    //                newMaterial.color = findcolor(SmokeyController.instantiators[i].color);
    //                dataTrf.GetComponent<Renderer>().material = newMaterial;
    //                if (dataTrf.GetComponent<Renderer>().material.color == Color.blue)
    //                {
    //                    pos.y = dp.localPosition.z * 4.5f + 4.5f;
    //                }
    //                else if (dataTrf.GetComponent<Renderer>().material.color == Color.black)
    //                {
    //                    pos.y = dp.localPosition.z * 4.5f + 4f;
    //                }
    //                else if (dataTrf.GetComponent<Renderer>().material.color == new Color(1, 0.5f, 0))
    //                {
    //                    pos.y = dp.localPosition.z * 4.5f + 4f;
    //                }
    //                else if (dataTrf.GetComponent<Renderer>().material.color == Color.gray)
    //                {
    //                    pos.y = dp.localPosition.z * 4.5f + 4.5f;
    //                }
    //                else if (dataTrf.GetComponent<Renderer>().material.color == Color.white)
    //                {
    //                    pos.y = dp.localPosition.z * 4.5f + 4f;
    //                }
    //                else if (dataTrf.GetComponent<Renderer>().material.color == new Color(1f, 0.2f, 0.45f))
    //                {
    //                    pos.y = dp.localPosition.z * 4.5f + 4f;
    //                }
    //                pos.x = dp.localPosition.x * 4.5f - 13f;
    //                pos.z = -0.12f;
    //                dataTrf.localPosition = pos;
    //                dataTrf.localScale = new Vector3(scale, scale, scale);
    //                dataTrf.gameObject.SetActive(true);
    //                dataTrf.GetComponent<PrefabID>().id = nodeSize;
    //                nodeSize++;
    //                SmokeyController.allLayeredNodes.Add(dataTrf);
    //            }
    //            else { print("node is null"); }
    //        }
    //        mapIndex++;
    //    }
    //}

    public static void display()
    {
        foreach (Transform tp in layers)
        {
            tp.gameObject.SetActive(true);
        }
    }
    public static void hideLayers()
    {
        foreach(Transform tp in layers)
        {
            tp.gameObject.SetActive(false);
        }
    } 

    public static void BuildLayers (Transform parentMap, Transform node) 
	{	
		layersActive = true;
		if (layers == null)
		{
			layers = new List<Transform>();
		}
        for (int i = 0; i < 10; i++)
        {
            Transform map = HeightMapSelection.InstantiateMap(parentMap);

            if (layers.Count > 0)
            {
                map.parent = Subspaces.focus1;
                map.localPosition = new Vector3(0, 0.4f - (i * 0.02f), -(i + 1) * Zoffset); // all other maps
            }
            else
            {
                map.position = Vector3.zero;
                map.parent = Subspaces.focus1;
                map.localPosition = new Vector3(0, 0.4f, -15f);         // first map
            }
            var collider = map.transform.gameObject.AddComponent<BoxCollider>();
            map.name = "layer" + (i+1);
            layers.Add(map);
        }
        dateNode = node;
        addDatatoMaps();
	}
    public static void furtherData()
    {
        for(int i = 0; i < 5; i++)
        {
            foreach(Transform dp in SmokeyController.instantiators[i].dataPoints)
            {
                Transform dataTrf = GameObject.Instantiate(dateNode) as Transform;
                dataTrf.parent = layers[i+10];
                var pos = dp.localPosition;
                Material newMaterial = new Material(Shader.Find("VertexLit"));
                newMaterial.color = findcolor(SmokeyController.instantiators[i].color);
                dataTrf.GetComponent<Renderer>().material = newMaterial;
                pos.y = dp.localPosition.y * 20f - 2f;
                pos.x = dp.localPosition.x * 32f;
                pos.z = -0.12f;
                dataTrf.localPosition = pos;
                dataTrf.localScale = new Vector3(scale, scale, scale);
                dataTrf.localRotation = Quaternion.identity;
                dataTrf.gameObject.SetActive(true);
            }
        }
    }

    public static void addDatatoMaps() {
        for(int i = 0; i < 10; i++)
        {
            foreach (Transform dp in SmokeyController.instantiators[i].dataPoints)
            {
                if (dateNode != null)
                {
                    Transform dataTrf = GameObject.Instantiate(dateNode) as Transform;
                    dataTrf.parent = layers[i];
                    var pos = dp.localPosition;
                    Material newMaterial = new Material(Shader.Find("VertexLit"));
                    newMaterial.color = findcolor(SmokeyController.instantiators[i].color);
                    dataTrf.GetComponent<Renderer>().material = newMaterial;
                    pos.y = dp.localPosition.y * 20f - 2f;
                    pos.x = dp.localPosition.x * 32f;
                    pos.z = -0.12f;
                    dataTrf.localPosition = pos;
                    dataTrf.localScale = new Vector3(scale, scale, scale);
                    dataTrf.localRotation = Quaternion.identity;
                    dataTrf.gameObject.SetActive(true);
                    dataTrf.GetComponent<PrefabID>().id = nodeSize;
                    dataTrf.name = SmokeyController.instantiators[i].name1 + "_" + SmokeyController.instantiators[i].color + "_(layeredMap)";
                    nodeSize++;
                    SmokeyController.allLayeredNodes.Add(dataTrf);
                    SmokeyController.LayeredHabitats.Add(dataTrf.gameObject);
                }
                else { print("node is null"); }
            }
        }
    }

    public static Color findcolor(string color)
    {
        Color outt = Color.green;
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
                outt = Color.black;
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
    static Vector3 temp;
    public static void flatten() {
        temp = layers[0].localPosition;
        for (int i = 0; i < layers.Count; i++)
        {
             layers[i].gameObject.SetActive(false);
        }
        layers[1].gameObject.SetActive(true);
        layers[1].localPosition = new Vector3(-0.02f, 0.015f, -1.02f);
    }

    public static void unflatten() {
        foreach (Transform item in layers)
        {
            item.gameObject.SetActive(true);
        }
        layers[0].localPosition = temp;
    }

    public static void resetLayerPos()
    {
        layers[0].localPosition = new Vector3(0, 0.4f, -15f);

        for (int i = 1; i < layers.Count; i++)
        {
            layers[i].localPosition = new Vector3(0, 0.4f - (i * 0.02f), -(i + 1) * Zoffset);
        }
    }
}