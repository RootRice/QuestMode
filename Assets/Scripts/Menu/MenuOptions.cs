using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour {

    public GameObject activeMenu;

    // Use this for initialization
    void Start ()
    {
      
       

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void changeActive(GameObject menuToSet)
    {

        activeMenu.SetActive(false);
        activeMenu = menuToSet;
        menuToSet.SetActive(true);

    }
}
