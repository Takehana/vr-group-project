using UnityEngine;
using System.Collections;

//Geoffrey Herz

//Place on a gameobject and that gameobject will begin to bob up and down following a sine wave motion. 
//This motion can be modified to move in all 3 directions, distance traveled, and the period it takes to complete one cycle. 
//Will bug out if the object is under another script to move around. Could be fixed by using localPosition. 

public class LinearMovement : MonoBehaviour {

    public float distance = 1.0f;
    public float periodModifier = 0.5f;
    public bool reverseY = false;
    public bool reverseX = false;
    public bool reverseZ = false;
    public bool moveZ = false;
    public bool moveY = true;
    public bool moveX = false;

    Vector3 floatX;
    Vector3 floatY;
    Vector3 floatZ;
    Vector3 originalX;
    Vector3 originalY;
    Vector3 originalZ;

    // Saving the original position of the gameobject 
    void Start () {
        originalY = transform.position;
        originalX = transform.position;
        originalZ = transform.position;
    }
	
    // Calls X, Y, Z as cleared to start moving if the option was selected. 
	void Update () {
        if (moveZ == true) Run('z');
        if (moveY == true) Run('y');
        if (moveX == true) Run('x');
    }

    //Traffic control, orders motion to start in the directions specified by the developer. 
    void Run(char n){
        switch (n)
        {
            case 'x':
                StartMotionX(reverseX);
                break;
            case 'y':
                StartMotionY(reverseY);
                break;
            case 'z':
                StartMotionZ(reverseZ);
                break;

            default: break;
        }
    }

    //Animates motion in specified direction, with the correct reverse, time and distance. 
    //Input parameter: Reverse - On/off switch passed in so that the function knows if it should reverse the sine wave. 
    //Why: Keeping it split into three functions dedicated to X, Y and Z is more readable then making a single generic function, desipte the code being almost identicle to one another. 
    void StartMotionY(bool reverse){
        floatY = transform.position;
        floatY.y = (Decide(reverse)) *(Mathf.Sin(Time.time * periodModifier) * distance) + originalY.y;
        transform.position = floatY;
    }

    void StartMotionX(bool reverse){
        floatX = transform.position;
        floatX.x = (Decide(reverse)) * (Mathf.Sin(Time.time * periodModifier) * distance) + originalX.x;
        transform.position = floatX;
    }

    void StartMotionZ(bool reverse){
        floatZ = transform.position;
        floatZ.z = (Decide(reverse)) * (Mathf.Sin(Time.time * periodModifier) * distance) + originalZ.z;
        transform.position = floatZ;
    }

    //Helper function. Given Reverse: A true returns -1, a false returns 1. 
    //Why: Using just the bool itself to be read as an int would return 0 as false, we have to modify it so false is read as 1. 
    int Decide(bool reverse){
        if (reverse == true) return -1;
        return 1;
    }
}
