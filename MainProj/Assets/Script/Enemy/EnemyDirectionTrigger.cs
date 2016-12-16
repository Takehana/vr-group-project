using UnityEngine;
using System;
using System.Collections;

//Attach to collider at end of tunnel so enemies follow tunnel backwards.
//Allows for BasicEnemyMovement script to detect the tunnel it is in and
//adjust it's vector direction accordingly. 
public class EnemyDirectionTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            GameObject enemy = collider.gameObject;
            BasicEnemyMovement enemy_Movement = enemy.GetComponent<BasicEnemyMovement>();
            GameObject tunnel = transform.parent.gameObject;
            enemy_Movement.set_Tunnel_Type(tunnel);
            print(tunnel.name + ": is triggered");
        }
    }
}
