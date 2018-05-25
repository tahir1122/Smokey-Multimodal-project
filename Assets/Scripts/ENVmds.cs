using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ENVmds : MonoBehaviour
{
    static float xOffset = -0.4f;
    static float yOffset = -1.9f;
    static float zOffset = 0.4f;
    private static List<float> Xcoord = new List<float>();
    private static List<float> Ycoord = new List<float>();
    private static List<float> Zcoord = new List<float>();
    private static List<string> clusterID = new List<string>();

    public static void read()
    {
        StringReader reader;
        string txt = "";
        TextAsset x = (TextAsset)Resources.Load("env_mdsX", typeof(TextAsset));
        reader = new StringReader(x.text);
        while ((txt = reader.ReadLine()) != null)
        {
            Xcoord.Add(float.Parse(txt));
        }

        TextAsset y = (TextAsset)Resources.Load("env_mdsY", typeof(TextAsset));
        reader = new StringReader(y.text);
        while ((txt = reader.ReadLine()) != null)
        {
            Ycoord.Add(float.Parse(txt));
        }

        TextAsset z = (TextAsset)Resources.Load("env_mdsZ", typeof(TextAsset));
        reader = new StringReader(z.text);
        while ((txt = reader.ReadLine()) != null)
        {
            Zcoord.Add(float.Parse(txt));
        }

        TextAsset id = (TextAsset)Resources.Load("env_mdsCluster", typeof(TextAsset));
        reader = new StringReader(id.text);
        while ((txt = reader.ReadLine()) != null)
        {
            clusterID.Add(txt);
        }
        //print(Xcoord.Count + " " + Ycoord.Count + " " + Zcoord.Count + " " + clusterID.Count);
        makePlot();
    }
    public static void makePlot()
    {
        float scale = 0.02f;
        for (int i = 0; i < Zcoord.Count; i++)
        {
            var dataPt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            dataPt.transform.parent = Subspaces.focus4;
            dataPt.transform.localPosition = new Vector3((Xcoord[i] / 1.4f) + xOffset, (Zcoord[i] / 1.5f - 0.8f) + zOffset, (Ycoord[i] * -20) + yOffset);
            dataPt.transform.localRotation = Quaternion.identity;
            dataPt.transform.localScale = new Vector3(scale, scale, scale * 20); dataPt.name = i.ToString();
            Material newMaterial = new Material(Shader.Find("VertexLit"));
            newMaterial.color = findColor(clusterID[i]);
            dataPt.GetComponent<Renderer>().material = newMaterial;
            dataPt.layer = LayerMask.NameToLayer("Ignore Raycast");
            dataPt.gameObject.SetActive(true);
        }
    }

    public static Color findColor(string color)
    {
        Color outt = Color.white;
        switch (color)
        {
            case "1":
                outt = Color.green;
                break;
            case "2":
                outt = Color.blue;
                break;
            case "3":
                outt = Color.red;
                break;
            case "4":
                outt = Color.yellow;
                break;
        }
        return outt;
    }

}
