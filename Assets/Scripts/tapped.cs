using UnityEngine;

public class tapped : MonoBehaviour
{
    public bool active = true;
    void OnSelect()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if(MI.color == "red")
                {
                    foreach(Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.green)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "green")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "yellow")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.magenta)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "magenta")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.cyan)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "cyan")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "blue")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.white)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "white")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == new Color(1, 0.5f, 0))
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "orange")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.gray)
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "gray")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
        if (gameObject.GetComponent<Renderer>().material.color == new Color(1f, 0.2f, 0.45f))
        {
            active = !active;
            foreach (ModelInstantiator MI in SmokeyController.instantiators)
            {
                if (MI.color == "purple")
                {
                    foreach (Transform dp in MI.dataPoints)
                    {
                        dp.gameObject.SetActive(active);
                        SmokeyController.allLayeredNodes[dp.gameObject.GetComponent<PrefabID>().id].gameObject.SetActive(active);
                    }
                }
            }
        }
    }
}