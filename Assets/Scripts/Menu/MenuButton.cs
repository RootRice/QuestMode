using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public GameObject myMenu;
    MenuOptions myMenuOptions;
    public GameObject relevantMenu;

    // Use this for initialization
    void Start ()
    {
        
        myMenuOptions = myMenu.GetComponent<MenuOptions>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        myMenuOptions.changeActive(relevantMenu);
    }
}
