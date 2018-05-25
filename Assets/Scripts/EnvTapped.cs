using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnvTapped : MonoBehaviour {
    public int ID;
    public bool active = false;
    public static float scale = .3f;

    public static float x = 10f;
    public static float y = 0f;
    public static float z = -3f;
    Transform myMap = null;

    void OnSelect()
    {
        active = !active;
        if (active)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            SmokeyController.makeENVlayer(ID);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            SmokeyController.removeENVlayer(ID);
        }
    }
}
