using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    Enemy enemyToAttack;
    public GameObject myPlayerCharacter;
    PlayerCharacter playerCharacterScript;
    Collider2D myCollider;

    // Use this for initialization
    void Start ()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
        playerCharacterScript = myPlayerCharacter.GetComponent<PlayerCharacter>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    

    private void OnTriggerStay2D(Collider2D other)
    {
        
        
            if (other.gameObject.CompareTag("Enemy"))
            {

                playerCharacterScript.shouldAttack = true;
                playerCharacterScript.SetEnemy(other.gameObject.GetComponent<Enemy>());
                myCollider.enabled = false;


            }
        
    }

    public void resetEnemy()
    {

        enemyToAttack = null;
        myCollider.enabled = true;

    }
}
