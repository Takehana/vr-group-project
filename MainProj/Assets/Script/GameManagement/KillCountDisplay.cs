using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//by Shao
public class KillCountDisplay : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    //display kill count and highest kill count
    void Update()
    {
        text.text = "Enemies Destroyed:\n" + (int)scoreKeeper.killCount
            + "\nHighest Kill:\n" + PlayerPrefs.GetInt("highKill", 0); ;
    }
}
