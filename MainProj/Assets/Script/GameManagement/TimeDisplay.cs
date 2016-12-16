using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//by Shao
public class TimeDisplay : MonoBehaviour {

    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    //display time survived and longest time survived
    void Update()
    {
        text.text = "Time Survived:\n" + (int)scoreKeeper.time
            + "\nLongest Time:\n" + PlayerPrefs.GetInt("timeSurvived", 0); ;
    }
}
