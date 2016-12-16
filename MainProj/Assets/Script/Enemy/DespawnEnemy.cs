using UnityEngine;
using System.Collections;

//Written by Henry
//Apply to a large collider a fixed distance behind the player
//to despawn enemies when they are no longer relevent. 
//Can also be used for collision detection that involves killing enemies.
public class DespawnEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(collider.gameObject);
        }
    }
}

