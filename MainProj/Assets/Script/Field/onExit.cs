using UnityEngine;
using System.Collections;

//by Shao
public class onExit : MonoBehaviour {

    public GameObject tunnel;

    //destroy the field upon exiting so save memory
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "player")
            Destroy(tunnel);
    }
}
