using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    Collider2D myCollider;

    public bool shouldAttack;

    Enemy enemyToAttack;
    GameObject myGameManager;
    LevelManager myLevelManager;
    Attack myAttack;

    public GameObject myHealthBar;

    public GameObject myAttackBox;

    float attackTimer;
    float attackCooldown;
    public int attackDamage;

    private float maxHP;
    public float HP;
    public float Armour;

    Animator myAnimator;

    // Use this for initialization
    void Start ()
    {
        maxHP = HP;
        myAttack = myAttackBox.GetComponent<Attack>();
        myCollider = gameObject.GetComponent<Collider2D>();
        attackCooldown = 0.5f;
        attackDamage = 2;
        Armour = 0.5f;
        myGameManager = GameObject.FindGameObjectWithTag("GameManager");
        myLevelManager = myGameManager.GetComponent<LevelManager>();
        myAnimator = gameObject.GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        myHealthBar.transform.localScale = new Vector3(HP / maxHP, myHealthBar.transform.localScale.y);
        if (HP <= 0)
        {
            
            myCollider.enabled = false;
            shouldAttack = false;
            gameObject.SetActive(false);

        }
        if (myLevelManager.moving)
        {
            myAnimator.SetBool("ShouldMove", true);
        }
        else
        {
            myAnimator.SetBool("ShouldMove", false);
        }
		if (shouldAttack)
        {
            myAnimator.SetBool("ShouldAttack", true);
            attackTimer += Time.deltaTime;
            if (attackTimer > attackCooldown)
            {

                attackTimer += Time.deltaTime;
                if (attackTimer > attackCooldown)
                {

                    attackTimer = 0;
                    enemyToAttack.HP -= attackDamage * enemyToAttack.Armour;
                    if (enemyToAttack.HP <= 0)
                    {
                        shouldAttack = false;
                        myAttack.resetEnemy();

                    }

                }

            }
            
        }
        else
        {
            myAnimator.SetBool("ShouldAttack", false);
        }
	}

    

    public void SetEnemy(Enemy enemyToSet)
    {

        enemyToAttack = enemyToSet;

    }
}
