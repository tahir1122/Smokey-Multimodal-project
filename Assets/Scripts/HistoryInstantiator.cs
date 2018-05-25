using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryInstantiator : MonoBehaviour
{

    public int dataset = 0;
    bool active = false;

    public List<string> layerName = new List<string>();
    public List<Vector3> layerPos = new List<Vector3>();

    public List<int> envID = new List<int>();
    public List<Vector3> envPos = new List<Vector3>();

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.gray;
    }

    void OnSelect()
    {
        if (!active) 
        {
            active = true;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            LayeredMapping.resetLayerPos();
            SmokeyController.DeleteAllENV();
            //if (dataset == 1)
            //{
            //    for (int i = 0; i < SmokeyController.allHabitats.Count; i++)
            //    {
            //        SmokeyController.allHabitats[i].SetActive(false);
            //        SmokeyController.LayeredHabitats[i].SetActive(false);
            //    }
            //    for (int i = SmokeyController.batchCount; i < SmokeyController.allHabitats.Count; i++)
            //    {
            //        SmokeyController.allHabitats[i].SetActive(true);
            //        SmokeyController.LayeredHabitats[i].SetActive(true);
            //    }
            //    FilteringSpecies.changeText1();
            //}
            //else if (dataset == 2)
            //{
            //    for (int i = 0; i < SmokeyController.batchCount; i++)
            //    {
            //        SmokeyController.allHabitats[i].SetActive(true);
            //        SmokeyController.LayeredHabitats[i].SetActive(true);
            //    }
            //    for (int i = SmokeyController.batchCount; i < SmokeyController.allHabitats.Count; i++)
            //    {
            //        SmokeyController.allHabitats[i].SetActive(false);
            //        SmokeyController.LayeredHabitats[i].SetActive(false);
            //    }
            //    FilteringSpecies.changeText();
            //}



            for (int i = 0; i < layerName.Count; i++)             // placing transparent layers in the positions when history was recorded
            {
                var obj = GameObject.Find(layerName[i]);
                obj.transform.localPosition = layerPos[i];
            }



            for (int i = 0; i < envID.Count; i++)                // creating and placing env layers
            {
                int id = envID[i];
                SmokeyController.makeENVlayer(id);
                foreach (Transform item in SmokeyController.allENVlayers)
                {
                    if (item.name.Equals(id.ToString()))
                    {
                        item.localPosition = envPos[i];
                    }
                }
            }
        }
        else if (active)
        {
            active = false;
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            LayeredMapping.resetLayerPos();
            SmokeyController.DeleteAllENV();
            // reset data to first dataset
        }
    }
}
