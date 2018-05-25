using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilteringTypes : MonoBehaviour
{
    public static float scale1 = 0.025f;
    public static float textscale = 0.6f;
    static float x = -0.43f;
    static float y = 0f;
    static float y1 = -0.18f;
    static float z = -2.5f;

    public static void filter_nodes(Transform prefab, Transform textPrefab)
    {
        if (prefab == null) { print("NO PREFAB OF NODE FOUND/ATTACHED"); }
        int i = 0;
        int j = 0;
        for(int iter = 0; iter < ServerStream.allNames.Count; iter++)
        {
            if (i < 7)
            {
                Transform dataTrf = Instantiate(prefab) as Transform;
                dataTrf.SetParent(Subspaces.focus25);
                dataTrf.localPosition = new Vector3(x + i * 0.14f, y+0.47f, z);
                dataTrf.localScale = new Vector3(scale1, scale1, 0.01f);
                dataTrf.localRotation = Quaternion.identity;
                dataTrf.gameObject.SetActive(true);
                dataTrf.name = "Filter_button_"+ServerStream.allNames[iter];
                Material newMaterial = new Material(Shader.Find("VertexLit"));
                newMaterial.color = Color.gray;
                dataTrf.GetComponent<Renderer>().material = newMaterial;
                dataTrf.GetComponent<FilteringTapped>().ID = iter;
                if(iter == 0)
                {
                    //dataTrf.GetComponent<FilteringTapped>().startRange = 0;
                }
                else
                {
                    //dataTrf.GetComponent<FilteringTapped>().startRange = SmokeyController.AllbatchCounts[iter - 1];
                }
                //dataTrf.GetComponent<FilteringTapped>().endRange = SmokeyController.AllbatchCounts[iter];
                //if (i == 2)
                //{
                //    newMaterial.color = Color.green;
                //}
                var text = Instantiate(textPrefab);
                text.parent = dataTrf;
                text.localPosition = new Vector3(x, y - 2f, z + 1.6f);
                text.localScale = new Vector3(textscale, textscale, 0.001f);
                text.localRotation = Quaternion.Euler(270, 0, 0);
                text.Rotate(90, 0, 0);
                text.name = "Filter_button_" + ServerStream.allNames[iter];
                text.gameObject.SetActive(true);
                TextMesh theText = text.transform.GetComponent<TextMesh>();
                theText.text = ServerStream.allNames[iter];
                i++;
            }
            else
            {
                Transform dataTrf = Instantiate(prefab) as Transform;
                dataTrf.SetParent(Subspaces.focus25);
                dataTrf.localPosition = new Vector3(x + j * 0.14f, y - 0.2f, z);
                dataTrf.localScale = new Vector3(scale1, scale1, 0.01f);
                dataTrf.localRotation = Quaternion.identity;
                dataTrf.gameObject.SetActive(true);
                dataTrf.name = "Filter_button_" + ServerStream.allNames[iter];
                Material newMaterial = new Material(Shader.Find("VertexLit"));
                newMaterial.color = Color.gray;
                if(i == 11)
                {
                    newMaterial.color = Color.green;
                }
                dataTrf.GetComponent<Renderer>().material = newMaterial;
                dataTrf.GetComponent<FilteringTapped>().ID = iter;
                //dataTrf.GetComponent<FilteringTapped>().startRange = SmokeyController.AllbatchCounts[iter - 1];
                //dataTrf.GetComponent<FilteringTapped>().endRange = SmokeyController.AllbatchCounts[iter];

                var text = Instantiate(textPrefab);
                text.parent = dataTrf;
                text.localPosition = new Vector3(x - 0.1f, y - 1.7f, z + 3);
                text.localScale = new Vector3(textscale, textscale, 0.001f);
                text.localRotation = Quaternion.Euler(270, 0, 0);
                text.Rotate(90, 0, 0);
                text.name = "Filter_button_" + ServerStream.allNames[iter];
                text.gameObject.SetActive(true);
                TextMesh theText = text.transform.GetComponent<TextMesh>();
                theText.text = ServerStream.allNames[iter];
                j++; i++;
            }
        }
    }

}
