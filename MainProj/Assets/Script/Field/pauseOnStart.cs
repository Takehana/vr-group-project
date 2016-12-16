using UnityEngine;
using System.Collections;

//by Shao
public class pauseOnStart : MonoBehaviour {

	// pause the environment movment on starting the game
	void Update ()
    {
        if (scoreKeeper.time <= scoreKeeper.startDelay)
            transform.Translate(-environmentMovement.movingSpeed);
    }
}
