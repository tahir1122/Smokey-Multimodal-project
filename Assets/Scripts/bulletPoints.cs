using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPoints : MonoBehaviour {

	public static void make(Transform prefab, Transform text)
    {
        Color32 greyColour = new Color32(0xA5, 0xFF, 0xF0, 0xFF);
        for (int i = 0; i < 14; i++)
        {
            Transform green = GameObject.Instantiate(prefab) as Transform;
            green.transform.parent = TrackableMonitor.mTrackableBehaviour.transform;
            Material newMaterial = new Material(Shader.Find("Standard"));
            newMaterial.color = Color.gray;
            
            green.transform.localPosition = new Vector3(-0.3f, -0.2f, -0.83f - i*0.2f);
            green.transform.localScale = new Vector3(0.06f, 0.06f, 0.03f);
            //green.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            //green.gameObject.SetActive(true);
            green.GetComponent<Renderer>().material.color = Color.white;

            var text3 = Instantiate(text);
            text3.parent = TrackableMonitor.mTrackableBehaviour.transform;
            text3.localPosition = new Vector3(0.1f, -0.2f, -0.76f - i * 0.2f);
            text3.localScale = new Vector3(0.1f, 0.1f, 0.001f);
            text3.localRotation = Quaternion.Euler(270, 0, 0);
            text3.Rotate(180, 0, 0);
            text3.gameObject.SetActive(true);
            TextMesh theText3 = text3.transform.GetComponent<TextMesh>();
            theText3.text = ServerStream.allNames[i];
            theText3.color = Color.white;
            theText3.fontStyle = FontStyle.Bold;
        }
    }
}
