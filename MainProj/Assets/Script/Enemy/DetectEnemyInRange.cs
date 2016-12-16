using UnityEngine;
using System.Collections;

//Written by Henry
//A collision script for when the object is within player camera range.
//Causes enemy ship be tagged "Enemy_Active"
public class DetectEnemyInRange : MonoBehaviour {
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            GameObject enemy = collider.gameObject;
            BasicEnemyMovement enemy_Movement = enemy.GetComponent<BasicEnemyMovement>();
            enemy.tag = "Enemy_Active";
            
        }
    }
}
