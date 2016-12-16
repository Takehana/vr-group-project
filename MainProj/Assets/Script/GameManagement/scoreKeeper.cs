using UnityEngine;
using System.Collections;

//by Shao
public class scoreKeeper : MonoBehaviour {

    public static float score;
    public static float time;
    public static float multiplier;
    public static float startDelay = 5;
    public static float killCount;
    int highScore;
    int highestKill;
    int longestTime;

	//set score. kill count, time to 0 on start
    //get history highest rankings
	void Start () {
        score = 0;
        killCount = 0;
        time = 0;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        highestKill = PlayerPrefs.GetInt("highKill", 0);
        longestTime = PlayerPrefs.GetInt("timeSurvived", 0);
    }
	
	//earn score as time pass
    //update highest rankings if new record made
	void Update () {
        time += Time.deltaTime;
        if (time <= startDelay)
            return;
        score += Time.deltaTime * multiplier;
        // print(score);

        if (score > highScore)
            PlayerPrefs.SetInt("highScore", (int)score);
        if (killCount > highestKill)
            PlayerPrefs.SetInt("highKill", (int)killCount);
        if (time > longestTime)
            PlayerPrefs.SetInt("timeSurvived", (int)time);
	}
}
