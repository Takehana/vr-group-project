using UnityEngine;
using System.Collections;

//Written by Henry Tran
//Place on spawnSpot collider so that when player passes through,
//Enemy Spawner System will move it's spawner to the end of the tunnel.
//The spawner will stay attached to the end of the tunnel until player 
//triggers another collider.  
//This script ensures that the spawner is always at the end of the tunnel
//opposite to the player.
public class MoveSpawner : MonoBehaviour {
    GameObject spawner;
    GameObject collider_End;
    public Vector3 distance_From_Collider = new Vector3(0.0f, 0.0f, 0.0f);

    //When this script is triggered, it will move the spawner to the
    //furthest end of the tunnel. 
    void Start () {
        spawner = GameObject.Find("Spawner");
        GameObject end_Tunnel = find_Tunnel_End();
        collider_End = end_Tunnel.transform.GetChild(0).gameObject;
        Vector3 new_Position = collider_End.transform.position;
        spawner.transform.position = new_Position + distance_From_Collider;
        spawner.tag = "Spawner";
    }

    //Keep's the spawner at the end of the furthest tunnel.
    void Update()
    {
        spawner.transform.position = collider_End.transform.position 
            + distance_From_Collider;
    }

    //Finds the tunnel furthest from the player. 
    GameObject find_Tunnel_End()
    {
        GameObject[] current_Tunnels = GameObject.FindGameObjectsWithTag("Field");
        GameObject tunnel_End = null;
        foreach (GameObject tunnel in current_Tunnels)
        {
            if(tunnel_End == null || tunnel.transform.position.z > tunnel_End.transform.position.z)
            {
                tunnel_End = tunnel;
            }
        }
        return tunnel_End;
    }
}
