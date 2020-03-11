using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour {

    

    void Start()
    {
        GetComponent<Renderer>().sortingOrder = 10;
        //Debug.Log(GetComponent<Renderer>().sortingLayerName);
    }
}

