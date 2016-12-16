using UnityEngine;
using System.Collections;

//by Shao
public class environmentMovement : MonoBehaviour {
    public static Vector3 movingSpeed;

	//keep the environment moving
	void Update ()
    {
        transform.Translate(movingSpeed);
	
	}
}
