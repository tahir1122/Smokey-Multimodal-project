using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class scatterplot : MonoBehaviour {
    private static string txt = "";
    //private static float scale = 0.1f;
    private static float scale = 0.02f;
    static float xOffset = -0.4f;
    static float yOffset = -1.9f;
    static float zOffset = 0.5f;
    static StringReader reader;
    private static List<float> Xcoord = new List<float>();
    private static List<float> Ycoord = new List<float>();
    private static List<float> Zcoord = new List<float>();
    private static List<string> clusterID = new List<string>();
    //public static Transform datapoint;

    public static void read()
    {
        TextAsset x = (TextAsset)Resources.Load("mds-x", typeof(TextAsset));
        reader = new StringReader(x.text);
        while ((txt = reader.ReadLine()) != null)
        {
            Xcoord.Add(float.Parse(txt));
        }
        
        TextAsset y = (TextAsset)Resources.Load("mds-y", typeof(TextAsset));
        reader = new StringReader(y.text);
        while ((txt = reader.ReadLine()) != null)
        {
            Ycoord.Add(float.Parse(txt));
        }

        TextAsset z = (TextAsset)Resources.Load("mds-z", typeof(TextAsset));
        reader = new StringReader(z.text);
        while ((txt = reader.ReadLine()) != null)
        {
            Zcoord.Add(float.Parse(txt));
        }

        TextAsset id = (TextAsset)Resources.Load("clusterID", typeof(TextAsset));
        reader = new StringReader(id.text);
        while ((txt = reader.ReadLine()) != null)
        {
            clusterID.Add(txt);
        }
        makePlot();
    }
    public static void makePlot()
    {
        for(int i = 0; i<Zcoord.Count; i++)
        {
            //Transform dataPt = GameObject.Instantiate (datapoint) as Transform;
            //dataPt.parent = Subspaces.focus;
            //dataPt.parent = TrackableMonitor.mTrackableBehaviour.transform;
            //dataPt.localPosition = new Vector3((Xcoord[i]*5f)+xOffset, (Zcoord[i]*2f)+zOffset, (Ycoord[i]*3)+yOffset);
            //dataPt.localRotation = Quaternion.identity;
            //dataPt.localScale = new Vector3(scale, scale, scale); dataPt.name = i.ToString();
            //Material newMaterial = new Material(Shader.Find("VertexLit"));
            //newMaterial.color = findColor(clusterID[i]);
            //if (i == 479 || i == 732){newMaterial.color = Color.red;}
            //dataPt.GetComponent<Renderer>().material = newMaterial;
            //dataPt.gameObject.SetActive(true);

            var dataPt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            dataPt.transform.parent = Subspaces.focus3;
            dataPt.transform.localPosition = new Vector3((Xcoord[i]/1.4f) + xOffset, (Zcoord[i]/1.5f - 0.8f) + zOffset, (Ycoord[i] *-20) + yOffset);
            dataPt.transform.localRotation = Quaternion.identity;
            dataPt.transform.localScale = new Vector3(scale, scale, scale*20); dataPt.name = i.ToString();
            Material newMaterial = new Material(Shader.Find("VertexLit"));
            newMaterial.color = findColor(clusterID[i]);
            if (i == 479 || i == 732) { newMaterial.color = Color.red; }
            dataPt.GetComponent<Renderer>().material = newMaterial;
            dataPt.layer = LayerMask.NameToLayer("Ignore Raycast");
            dataPt.gameObject.SetActive(true);

        }
        //var Xaxis = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Xaxis.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        //Xaxis.transform.localPosition = new Vector3(14f, 0, -1.5f);
        //Xaxis.transform.localScale = new Vector3(0.04f, 4.5f, 0.04f);
        //Xaxis.gameObject.SetActive(true);

        //var Yaxis = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Yaxis.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        //Yaxis.transform.localPosition = new Vector3(17f, 0, -3.75f);
        //Yaxis.transform.localScale = new Vector3(0.04f, 6f, 0.04f);
        //Yaxis.transform.localRotation = Quaternion.Euler(0, 0, 270);
        //Yaxis.gameObject.SetActive(true);

        //var Zaxis = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Zaxis.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        //Zaxis.transform.localPosition = new Vector3(14f, 1.25f, -3.75f);
        //Zaxis.transform.localScale = new Vector3(0.04f, 2.5f, 0.04f);
        //Zaxis.transform.localRotation = Quaternion.Euler(180, 0, 0);
        //Zaxis.gameObject.SetActive(true);

        //var start = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //start.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
        //start.transform.localPosition = new Vector3(14f, 0f, -3.75f);
        //start.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); Material newMaterial1 = new Material(Shader.Find("VertexLit"));
        //newMaterial1.color = Color.gray;
        //start.GetComponent<Renderer>().material = newMaterial1;
        //start.gameObject.SetActive(true);
    }

    public static Color findColor(string color) {
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
