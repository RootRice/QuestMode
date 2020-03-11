using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject pine1;
    public GameObject pine2;
    public GameObject clouds;

    private float gameTimer;

    public GameObject goblin1;
    bool goblin1Active;
    public GameObject goblin2;
    bool goblin2Active;
    public GameObject goblin3;
    bool goblin3Active;
    public GameObject goblin4;
    bool goblin4Active;
    public GameObject goblin5;
    bool goblin5Active;
    public GameObject goblinLeader;
    bool goblinLeaderActive;

    GameObject scoreScreen;

    public GameObject rewardText;
    public GameObject goblinsKilled;
    TextScript goblinsKilledText;
    public GameObject goblinsGold;
    TextScript goblinsGoldText;
    public GameObject leadersKilled;
    TextScript leadersKilledText;
    public GameObject leadersGold;
    TextScript leadersGoldText;
    public GameObject total;
    TextScript totalText;

    public GameObject ExitButton;

    public GameObject Particles;

    public int goblinCounter = 0;

    public int goblinKillCounter = 0;

    public int goblinLeaderKillCounter = 0;

    public bool moving;

    public bool gameRunning = true;

    float timer = 2;

	// Use this for initialization
	void Start ()
    {
        moving = true;
        goblinsKilledText = goblinsKilled.GetComponent<TextScript>();
        goblinsGoldText = goblinsGold.GetComponent<TextScript>();
        leadersKilledText = leadersKilled.GetComponent<TextScript>();
        leadersGoldText = leadersGold.GetComponent<TextScript>();
        totalText = total.GetComponent<TextScript>();
        scoreScreen = GameObject.FindGameObjectWithTag("ScoreScreen");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameRunning)
        {
            if (goblinCounter > 0)
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
            if (moving)
            {
                pine1.transform.position = new Vector3(pine1.transform.position.x + 0.1f * Time.deltaTime, pine1.transform.position.y);
                pine2.transform.position = new Vector3(pine2.transform.position.x - 0.1f * Time.deltaTime, pine2.transform.position.y);
                clouds.transform.position = new Vector3(clouds.transform.position.x + 0.1f * Time.deltaTime, clouds.transform.position.y);
            }
            gameTimer += Time.deltaTime;
            if (gameTimer > 5 && !goblin1Active)
            {
                goblinCounter++;
                goblin1Active = true;
                goblin1.GetComponent<Enemy>().SetMove(true);

            }
            else if (gameTimer > 7 && !goblin2Active)
            {
                goblinCounter++;
                goblin2Active = true;
                goblin2.GetComponent<Enemy>().SetMove(true);

            }
            else if (gameTimer > 9 && !goblin3Active)
            {
                goblinCounter++;
                goblin3Active = true;
                goblin3.GetComponent<Enemy>().SetMove(true);

            }
            else if (gameTimer > 11 && !goblin4Active)
            {
                goblinCounter++;
                goblin4Active = true;
                goblin4.GetComponent<Enemy>().SetMove(true);

            }
            else if (gameTimer > 15 && !goblin5Active)
            {
                goblinCounter++;
                goblin5Active = true;
                goblin5.GetComponent<Enemy>().SetMove(true);

            }
            else if (gameTimer > 20 && !goblinLeaderActive)
            {
                goblinCounter++;
                goblinLeaderActive = true;
                goblinLeader.GetComponent<Enemy>().SetMove(true);

            }
        }
        else
        {
            if (scoreScreen.transform.position != new Vector3(0, 0, 0))
            {
                scoreScreen.transform.position = Vector3.MoveTowards(scoreScreen.transform.position, new Vector3(0, 0, 0), 20 * Time.deltaTime);
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= 2)
                {
                    ExitButton.SetActive(true);
                    timer -= timer;
                    GameObject anvilSparks = Instantiate(Particles, new Vector3(Random.Range(-5.82f, -6.42f), Random.Range(1.27f, 1.67f), 0f), transform.rotation);
                    GameObject UISparks = Instantiate(Particles, new Vector3(Random.Range(6.15f, 6.55f), Random.Range(-1.97f, -2.37f), 0f), transform.rotation);

                    Destroy(anvilSparks, 2f);
                    Destroy(UISparks, 2f);
                }
            }
        }

    }

    public void setMoving(bool state)
    {

        moving = state;

    }

    public void calculateRewards()
    {

        goblinsKilledText.SetText("Goblin x" + goblinKillCounter.ToString());
        leadersKilledText.SetText("Goblin Leader x" + goblinLeaderKillCounter.ToString());

        goblinsGoldText.SetText("2gx" + goblinKillCounter.ToString());
        leadersGoldText.SetText("20gx" + goblinLeaderKillCounter.ToString());

        int goldToAdd = goblinKillCounter * 2 + goblinLeaderKillCounter * 20;
        totalText.SetText("Total" + (goblinKillCounter * 2 + goblinLeaderKillCounter * 20).ToString() + "g");

        int currentGold = PlayerPrefs.GetInt("Gold");
        PlayerPrefs.SetInt("Gold", currentGold + goldToAdd);

    }

    
}
