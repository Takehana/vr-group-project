using UnityEngine;
using System.Collections;

//by Shao
public class difficultySettings : MonoBehaviour {
    float timer = 0;
    public float speed; //initial speed
    public static int spawnRate; //current spawn rate
    public int defaultSpawnRate; //initial spawn rate
    public float speedRateOfChange; //acceleration
    public int spawnRateOfChange; //gain spawn rate
    public float speedCap; //max speed
    public float spawnRateCap; //max spawn rate
    public float multiplierAtStart; //initial score mutiplier
    public float multiplierIncrement; 

    //general setting of the game aspect
    void Start () {
        spawnRate = defaultSpawnRate;
        environmentMovement.movingSpeed = new Vector3(0, 0, -speed);
        buildField.spawnRate = spawnRate;
        scoreKeeper.multiplier = multiplierAtStart;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        //increase speed, spawn rate, score multiplier every 5 sec
        if (timer >= 5f)
        {
            increaseSpeed();
            increaseSpawnRate();
            increaseScoreMultiplier();
            /*print("Speed: " + -environmentMovement.movingSpeed.z
                + "     SpawnRate: " + buildField.spawnRate
                + "     Score: " + scoreKeeper.score.ToString("0"));*/
            timer = 0;
        }
    }

    void increaseSpeed()
    {
        if (speed <= speedCap)
        {
            speed += speedRateOfChange;
            environmentMovement.movingSpeed = new Vector3(0, 0, -speed);
        }
    }

    void increaseSpawnRate()
    {
        if (spawnRate <= spawnRateCap)
        {
            spawnRate += spawnRateOfChange;
            buildField.spawnRate = spawnRate;
        }
    }

    void increaseScoreMultiplier()
    {
        scoreKeeper.multiplier += multiplierIncrement;
    }
}
