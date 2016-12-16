using UnityEngine;
using System.Collections;

//Attach to collider at start of tunnel so enemies follow tunnel backwards.
//Not implemented.
public class EnemyDirectionTriggerReverse : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy_Active")
        {
            GameObject enemy = collider.gameObject;
            BasicEnemyMovement enemy_Movement = enemy.GetComponent<BasicEnemyMovement>();
            GameObject tunnel = gameObject;
            enemy_Movement.set_Tunnel_Type(tunnel);
            print(tunnel.name+ ": is triggered");
        }
    }
}
