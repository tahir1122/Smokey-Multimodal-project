using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceTapped : MonoBehaviour {
    public int ID;
    void OnSelect()
    {
        Subspaces.space_tap(ID);
    }
}
