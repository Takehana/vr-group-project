using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//by Shao & Gabe
public class ScoreDisplay : MonoBehaviour {
	
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> (); 

    }
	
	//display score and high score
	void Update () {
        text.text = "Your Score:\n" + (int)scoreKeeper.score
            //+ "\nHigh Score:\n" + scoreKeeper.highScore
            + "\nHigh Score:\n" + PlayerPrefs.GetInt("highScore", 0); ;
	}
}
