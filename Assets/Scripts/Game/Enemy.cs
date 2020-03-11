using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool shouldMove;
    bool shouldAttack;

    public GameObject myHealthBar;

    float speed;

    float attackTimer;
    float attackCooldown;
    public int attackDamage;

    float maxHP;
    public float HP;
    public float Armour;

    PlayerCharacter playerToAttack;

    GameObject myGameManager;
    LevelManager myLevelManager;

    // Use this for initialization
    void Start ()
    {
        shouldMove = false;
        shouldAttack = false;
        attackCooldown = 1;
        
        speed = 10;

        maxHP = HP;

        myGameManager = GameObject.FindGameObjectWithTag("GameManager");
        myLevelManager = myGameManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myHealthBar.transform.localScale = new Vector3(HP / maxHP, myHealthBar.transform.localScale.y);
        if (HP <= 0)
        {
            
            myLevelManager.goblinCounter--;
            
            gameObject.GetComponent<Collider2D>().enabled = false;

            if (gameObject.name == "Goblin Leader")
            {

                myLevelManager.gameRunning = false;
                myLevelManager.goblinLeaderKillCounter++;
                myLevelManager.calculateRewards();
                gameObject.SetActive(false);
            }
            else
            {
                myLevelManager.goblinKillCounter++;
                gameObject.SetActive(false);
            }

            

        }
        if (shouldMove)
        {

            gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed*Time.deltaTime, gameObject.transform.position.y);

        }
        else if (shouldAttack)
        {

            attackTimer += Time.deltaTime;
            //print(attackTimer);
            if (attackTimer > attackCooldown)
            {

                attackTimer = 0;
                playerToAttack.HP -= attackDamage * playerToAttack.Armour;

            }

        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (playerToAttack == null)
        //{
            if (other.gameObject.CompareTag("Player"))
            {

                shouldAttack = true;
                shouldMove = false;
                playerToAttack = other.gameObject.GetComponent<PlayerCharacter>();

            }
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

            shouldAttack = false;
            shouldMove = true;
            playerToAttack = null;

        }

    }

    public void SetMove(bool state)
    {

        shouldMove = state;

    }
}
