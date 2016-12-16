using UnityEngine;
using System.Collections;

//Written by Henry Tran
//A script that move's colliders a fixed distance from the player. 

public class MoveCollider : MonoBehaviour {
    GameObject player;
    public Vector3 distance_From_Player = new Vector3(0.0f, 0.0f, -20.0f);

    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + distance_From_Player;
	}
}
