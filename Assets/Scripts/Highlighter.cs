using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour {

    public Transform whiteprefab;
    public Transform camera;
    
	void Start () {
        Color co = new Color(0,0,0,0.51f);
        GetComponent<SpriteRenderer>().color = co;
    }
	void Update ()
    {
        var pos = transform.position;
        pos.x = camera.transform.position.x;
        pos.y = camera.transform.position.y;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        Transform temp = SmokeyController.allLayeredNodes[collision.gameObject.GetComponent<PrefabID>().id];
        temp.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
    }
    private void OnCollisionExit(Collision collision)
    {
        Color clr = findcolor(collision.gameObject.name);
        collision.gameObject.GetComponent<MeshRenderer>().material.color = clr;
        Transform temp = SmokeyController.allLayeredNodes[collision.gameObject.GetComponent<PrefabID>().id];
        temp.gameObject.GetComponent<MeshRenderer>().material.color = clr;
    }

    public static Color findcolor(string color)
    {
        Color outt = Color.white;
        switch (color)
        {
            case "red":
                outt = Color.red;
                break;
            case "blue":
                outt = Color.blue;
                break;
            case "green":
                outt = Color.green;
                break;
            case "magenta":
                outt = Color.magenta;
                break;
            case "yellow":
                outt = Color.yellow;
                break;
            case "cyan":
                outt = Color.cyan;
                break;
            case "black":
                outt = Color.black;
                break;
            case "gray":
                outt = Color.gray;
                break;
            case "orange":
                outt = new Color(1, 0.5f, 0);
                break;
            case "purple":
                outt = new Color(1f, 0.2f, 0.45f);
                break;
        }
        return outt;
    }
}
