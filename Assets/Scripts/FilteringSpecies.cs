//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FilteringSpecies : MonoBehaviour {
//    //public static float scale = 0.1f;
//    public static float scale1 = 0.015f;
//    public static float textscale = 1f;
//    static float x = -0.42f;
//    static float y = 0f;
//    static float y1 = -0.18f;
//    static float z = -2.5f;
//    public static Transform red;
//    public static List<Transform> allFilters = new List<Transform>();
//    public static void filter_nodes(Transform prefab, Transform textPrefab)
//    {
//        if (prefab == null) { print("NO PREFAB OF NODE FOUND/ATTACHED"); }
//        int i = 0;
//        int j = 0;
//        foreach (ModelInstantiator MI in SmokeyController.instantiators)
//        {
//            if(i < 5)
//            {
//                Transform dataTrf = GameObject.Instantiate(prefab) as Transform;
//                dataTrf.SetParent(Subspaces.focus25);
//                dataTrf.localPosition = new Vector3(x + i * 0.18f, y-0.17f, z);
//                dataTrf.localScale = new Vector3(scale1, scale1, 1);
//                dataTrf.localRotation = Quaternion.identity;
//                dataTrf.gameObject.SetActive(true);
//                Material newMaterial = new Material(Shader.Find("VertexLit"));
//                newMaterial.color = ModelInstantiator.findcolor(MI.color);
//                dataTrf.GetComponent<Renderer>().material = newMaterial;
//                dataTrf.name = i.ToString();
//                if(i == 0)
//                {
//                    red = dataTrf;
//                }
//                var text = Instantiate(textPrefab);
//                text.parent = dataTrf;
//                text.localPosition = new Vector3(x, y-3f, z+3);
//                text.localScale = new Vector3(textscale, textscale, textscale);
//                text.localRotation = Quaternion.Euler(270,0,0);
//                text.Rotate(90, 0, 0);
//                text.gameObject.SetActive(true);
//                TextMesh theText = text.transform.GetComponent<TextMesh>();
//                theText.text = MI.name1;
//                allFilters.Add(text);
//                i++;
//            }
//            else
//            {
//                Transform dataTrf = GameObject.Instantiate(prefab) as Transform;
//                dataTrf.SetParent(Subspaces.focus25);
//                dataTrf.localPosition = new Vector3(x + j * 0.18f, y1 - 0.17f, z);
//                dataTrf.localScale = new Vector3(scale1, scale1, 1);
//                dataTrf.localRotation = Quaternion.identity;
//                dataTrf.gameObject.SetActive(true);
//                Material newMaterial = new Material(Shader.Find("VertexLit"));
//                newMaterial.color = ModelInstantiator.findcolor(MI.color);
//                dataTrf.GetComponent<Renderer>().material = newMaterial;

//                var text = Instantiate(textPrefab);
//                text.parent = dataTrf;
//                text.localPosition = new Vector3(x-0.1f , y-3f, z+3);
//                text.localScale = new Vector3(textscale, textscale, textscale);
//                text.localRotation = Quaternion.Euler(270, 0, 0);
//                text.Rotate(90, 0, 0);
//                text.gameObject.SetActive(true);
//                TextMesh theText = text.transform.GetComponent<TextMesh>();
//                theText.text = MI.name1;
//                allFilters.Add(text);
//                j++;i++;
//            }
//        }
//    }
//    public static void changeText() {
//        for(int i = 0; i<10;i++)
//        {
//            allFilters[i].GetComponent<TextMesh>().text = SmokeyController.allNames[i];
//        }
//    }
//    public static void changeText1()
//    {
//        for (int i = 10; i < 20; i++)
//        {
//            allFilters[i-10].GetComponent<TextMesh>().text = SmokeyController.allNames[i];
//        }
//    }
//}
