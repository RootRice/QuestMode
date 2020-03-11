using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextScript : MonoBehaviour {

    Text myText;

    public void SetText(string textToSet)
    {

        myText = gameObject.GetComponent<Text>();
        myText.text = textToSet;

    }

}
