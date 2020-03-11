using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentChoose : MonoBehaviour {

    public int equipment_type = -1;
    Vector3 initialPosition;
	// Use this for initialization
	void Start () {
        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseDown()
    {
        Vector3 posTargetHolder;
        posTargetHolder = GameObject.FindGameObjectWithTag("HelmetHolder").transform.position;
        if (equipment_type == 0)
        {
            //head
            posTargetHolder = GameObject.FindGameObjectWithTag("HelmetHolder").transform.position;
        }
        else if (equipment_type == 1)
        {
            //shoes
            posTargetHolder = GameObject.FindGameObjectWithTag("ShoeHolder").transform.position;
        }
        else if (equipment_type == 2)
        {
            //sowrd
            posTargetHolder = GameObject.FindGameObjectWithTag("MainHandHolder").transform.position;
        }
        else if (equipment_type == 3)
        {
            //shield
            posTargetHolder = GameObject.FindGameObjectWithTag("OffHandHolder").transform.position;
        }
        posTargetHolder.z = transform.position.z;
        if (posTargetHolder != null && posTargetHolder != transform.position)
        {
            if(equipment_type == 0)
            {
                if(!GameObject.FindGameObjectWithTag("HelmetHolder").GetComponent<ItemEquiped>().isEquippped)
                {
                    transform.position = posTargetHolder;
                    GameObject.FindGameObjectWithTag("HelmetHolder").GetComponent<ItemEquiped>().posOld = initialPosition;
                    GameObject.FindGameObjectWithTag("HelmetHolder").GetComponent<ItemEquiped>().isEquippped = true;
                }
            }
        }
        else
        {
            if (equipment_type == 0)
            {
                GameObject.FindGameObjectWithTag("HelmetHolder").GetComponent<ItemEquiped>().isEquippped = false;
            }
            transform.position = initialPosition;
        }
    }

}
