using UnityEngine;
using System.Collections;


//Geoffrey Herz

//Place on a gameobject and it will "drift" slightly behind the camera's motion. 
//Can modify how much drift distance in total and how reactive the motion will be. 
//Too much reaction and the object will start to jittery. 
public class CockpitDrift : MonoBehaviour {

    public float distanceMoved = 50.0f;
    public float reactiveModifier = 10.0f;

    private float orientationA;
    private float orientationB;
    private Vector3 originalPosition;
    private Vector3 newPosition;

    // Saving the original position of the gameobject 
    void Start () {
        originalPosition = transform.localPosition;
    }
	
    //Handles the drift. Note X and Y don't translate super well into spherical coordinates, had to create A and B which stores y and x
    //                   but then modified the opposite coordinate in newPosition(). It's weird. 
	void LateUpdate () {
        Quaternion headOrientation = GvrViewer.Instance.HeadPose.Orientation;

        orientationA = -headOrientation.y * Time.deltaTime * distanceMoved;
        orientationB = headOrientation.x * Time.deltaTime * distanceMoved;

        newPosition = new Vector3(originalPosition.x + orientationA, originalPosition.y + orientationB, originalPosition.z);
        transform.localPosition = Vector3.Slerp(transform.localPosition, newPosition, reactiveModifier * Time.deltaTime);
    }
}