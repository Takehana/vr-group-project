using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Geoffrey Herz


//Modifies a textMesh's text to match the current score.
//To use: Drag onto a gameobject that has a textMesh component. Nothing else needed.


public class HuDScoreKeeper : MonoBehaviour {

    static string format = "000.##";
    void Update(){GetComponent<TextMesh>().text = ((int)scoreKeeper.score).ToString(format);}

}
