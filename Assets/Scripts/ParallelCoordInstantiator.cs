using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelCoordInstantiator : MonoBehaviour
{
    public static float mapToCoordScale = 4.144218814753419f;
    public static float graphLength = 1.565275f * mapToCoordScale;
    public static float graphHeight = 0.3952875f * mapToCoordScale;
    //public static float offsetX = 1.609725f * mapToCoordScale;
    //public static float offsetY = 0.2524125f * mapToCoordScale;
    public static float offsetX = 1.609725f * mapToCoordScale;
    public static float offsetY = 0.2524125f * mapToCoordScale;
    //public static float offsetX = 3.609725f * mapToCoordScale;
    //public static float offsetY = 0.2524125f * mapToCoordScale;
    public static float scale = .01f;
    //public static float filter_scale = .15f;
    public static float filter_scale = 0.015f;
    public static List<Transform> dataPoints;
    public static List<Connection> connections;
    static float x = -0.47f;
    //static float y = -0.245f;
    static float y = -0.040f;
    static float z = -0.4f;
    public static List<GameObject> lines = new List<GameObject>();
    public static Connection conn;

    static float x1 = -0.47f;
    static float x2 = -0.47f;
    public static void environmentalLayers(Transform prefab)
    {
        for(int i = 0; i < 50; i++)
        { 
            Transform dataTrf = GameObject.Instantiate(prefab) as Transform;
            dataTrf.parent = Subspaces.focus2;
            dataTrf.localPosition = new Vector3(x, y, z);
            x = x + 0.019f;
            dataTrf.localScale = new Vector3(filter_scale, filter_scale, 0.02f);
            dataTrf.gameObject.SetActive(true);
            dataTrf.name = i.ToString();
            dataTrf.GetComponent<EnvTapped>().ID = i;
            dataTrf.GetComponent<Renderer>().material.color = Color.gray;
            dataTrf.name = "ENV_heatmap_button_" + (i+1);

            //GameObject slider = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //slider.transform.parent = Subspaces.focus2;
            //slider.transform.localPosition = new Vector3(x1, y+0.225f, z);
            //x1 = x1 + 0.019f;
            //slider.transform.localScale = new Vector3(0.0071f, 0.15f, 0.0001f);
            //slider.transform.GetComponent<Renderer>().material.color = Color.gray;
            ////if (i == 0 || i == 11)
            //if (true)
            //{
            //    slider.transform.GetComponent<Renderer>().material.color = Color.green;
            //}

            ////if (i == 0 || i == 11)
            //if (true)
            //{
            //    GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //    ball.transform.parent = Subspaces.focus2;
            //    ball.transform.localPosition = new Vector3(x2, 0.02f, z);
            //    ball.transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
            //    ball.transform.GetComponent<Renderer>().material.color = Color.white;
            //}
            
            //GameObject ball1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //ball1.transform.parent = Subspaces.focus2;
            //ball1.transform.localPosition = new Vector3(x2, 0.02f - 0.15f, z);
            //ball1.transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
            //ball1.transform.GetComponent<Renderer>().material.color = Color.white;

            //x2 = x2 + 0.019f;



            //for (int j = 0; j<2; j++)
            //{
            //    GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //    ball.transform.parent = Subspaces.focus2;
            //    ball.transform.localPosition = new Vector3(x2, 0.02f - j * 0.2f, z);
            //    ball.transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
            //    ball.transform.GetComponent<Renderer>().material.color = Color.white;
            //    if(j%2 == 0)
            //    {
            //        x2 = x2 + 0.019f;
            //    }
            //    if(i == 49 && j == 1)
            //    {
            //        ball.transform.localPosition = new Vector3(-0.47f, 0.02f - j * 0.2f, z);
            //    }
            //}
        }
    }
    public static void InstantiateSelection(List<List<double>> features, List<List<double>> axisRanges, Transform prefab)
    {
        connections = new List<Connection>();
        conn = new Connection();
        int axisNumber = features[0].Count;
        int count;
        int featureSetCount = 0;
        if (dataPoints == null)
        {
            dataPoints = new List<Transform>();
        }
        foreach (List<double> featureSet in features)
        {
            count = 0;
            foreach (double coordinate in featureSet)
            {

                dataPoints.Add(InstantiateDataPoint(graphLength / (axisNumber-1) * count, MinMax(axisRanges[count], coordinate) * graphHeight, prefab));
                if (count != 0)
                {
                    //print(dataPoints[count + featureSetCount]);
                    ConnectionManager.CreateConnection(dataPoints[count + featureSetCount - 1], dataPoints[count + featureSetCount]);
                    conn = ConnectionManager.FindConnection(dataPoints[count + featureSetCount - 1], dataPoints[count + featureSetCount]);
                    
                    //print(featureSetCount + " " + axisNumber);

                    if (featureSetCount == 0 || featureSetCount == axisNumber * 10)
                    {
                        conn.points[0].color = Color.red;
                        conn.points[1].color = Color.red; conn.name = "red_PCP_curve";
                    }
                    if (featureSetCount == axisNumber* 1 || featureSetCount == axisNumber*11)
                    {
                        conn.points[0].color = Color.green;
                        conn.points[1].color = Color.green; conn.name = "green_PCP_curve";
                    }
                    if (featureSetCount == axisNumber* 2 || featureSetCount == axisNumber * 12)
                    {
                        conn.points[0].color = Color.yellow;
                        conn.points[1].color = Color.yellow; conn.name = "yellow_PCP_curve";
                    }
                    if (featureSetCount == axisNumber* 3 || featureSetCount == axisNumber * 13)
                    {
                        conn.points[0].color = Color.magenta;
                        conn.points[1].color = Color.magenta; conn.name = "magenta_PCP_curve";
                    }
                    if (featureSetCount == axisNumber* 4 || featureSetCount == axisNumber * 14)
                    {
                        conn.points[0].color = Color.cyan;
                        conn.points[1].color = Color.cyan; conn.name = "cyan_PCP_curve";
                    }
                    if (featureSetCount == axisNumber * 5 || featureSetCount == axisNumber * 15)
                    {
                        conn.points[0].color = Color.blue;
                        conn.points[1].color = Color.blue; conn.name = "blue_PCP_curve";
                    }
                    if (featureSetCount == axisNumber * 6 || featureSetCount == axisNumber * 16)
                    {
                        conn.points[0].color = Color.yellow;
                        conn.points[1].color = Color.yellow; conn.name = "yellow_PCP_curve";
                    }
                    if (featureSetCount == axisNumber * 7 || featureSetCount == axisNumber * 17)
                    {
                        conn.points[0].color = new Color(1, 0.5f, 0);
                        conn.points[1].color = new Color(1, 0.5f, 0); conn.name = "orange_PCP_curve";
                    }
                    if (featureSetCount == axisNumber * 8 || featureSetCount == axisNumber * 18)
                    {
                        conn.points[0].color = Color.gray;
                        conn.points[1].color = Color.gray; conn.name = "gray_PCP_curve";
                    }
                    if (featureSetCount == axisNumber * 9 || featureSetCount == axisNumber * 19)
                    {
                        conn.points[0].color = new Color(95, 58, 101);
                        conn.points[1].color = new Color(95, 58, 101); conn.name = "white_PCP_curve";
                    }
                    conn.points[0].weight = .2f;
                    conn.points[1].weight = .2f;
                    connections.Add(conn);
                }
                count += 1;
            }
            featureSetCount += count;
        }
    }

    public static Transform InstantiateDataPoint(double longitude, double lattitude, Transform prefab)
    {
        Transform dataTrf = GameObject.Instantiate(prefab) as Transform;
        dataTrf.parent = Subspaces.focus2;
        float ss = (float)longitude / 7 - 0.471f;
        float tt = (float)lattitude / 5 + 0.08f;
        dataTrf.localPosition = new Vector3((float)longitude / 7 - 0.471f, (float)lattitude/5 + 0.08f, 0f);
        dataTrf.localRotation = Quaternion.Euler(-90, 0, 0);
        dataTrf.localScale = new Vector3(scale, scale, scale);
        dataTrf.gameObject.SetActive(true);
        //print(tt);
        //print("s" + ss);
        if (ss < -0.45)
        {
            dataTrf.gameObject.SetActive(true);
        }
        if(ss > -0.27 && ss < -0.23)
        {
            dataTrf.gameObject.SetActive(true);
        }
        if (tt < 0.081)
        {
            dataTrf.gameObject.SetActive(true);
        }
        lines.Add(dataTrf.gameObject);
        return dataTrf;
    }

    public static double MinMax(List<double> range, double coordinate)
    {
        return ((coordinate - range[0]) / (range[1] - range[0]));
    }

    public static void delete()
    {
        foreach(Transform item in dataPoints)
        {
            Destroy(item.gameObject);
        }
        dataPoints.Clear();
        foreach(Connection item in connections)
        {
            Destroy(item.gameObject);
        }
        connections.Clear();
    }
}
