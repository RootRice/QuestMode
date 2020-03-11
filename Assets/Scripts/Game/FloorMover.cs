using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMover : MonoBehaviour {
    float gameTimer;
    int moveCounter = 0;

    GameObject myGameManager;
    LevelManager myLevelManager;

    // Use this for initialization
    void Start ()
    {
        myGameManager = GameObject.FindGameObjectWithTag("GameManager");
        myLevelManager = myGameManager.GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (myLevelManager.moving == true)
        {
            gameTimer += Time.deltaTime;
            if (gameTimer >= 0.03f)
            {
                gameTimer -= gameTimer;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.25f, gameObject.transform.position.y);
                moveCounter++;
                if (moveCounter >= 32)
                {
                    
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + 8.0f, gameObject.transform.position.y);
                    
                    moveCounter = 0;
                }

            }
        }

	}
}
