using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilteringTapped : MonoBehaviour
{

    public int ID;
    public int startRange;
    public int endRange;
    public static bool active = false;

    void OnSelect()
    {
        active = !active;

        if (active)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            for (int i = startRange; i < endRange; i++)
            {
                SmokeyController.allHabitats[i].SetActive(true);
                SmokeyController.LayeredHabitats[i].SetActive(true);
            }
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            for (int i = startRange; i < endRange; i++)
            {
                SmokeyController.allHabitats[i].SetActive(false);
                SmokeyController.LayeredHabitats[i].SetActive(false);
            }
        }
    }
}
