using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//by Henry
public class EndGame : MonoBehaviour
{
    //end the game if player run into the following objects
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Wall" ||
            collider.gameObject.tag == "Enemy" ||
            collider.gameObject.tag == "Enemy_Active")
        {
            LevelManager.LoadNextScene();
            print("bump" + collider.gameObject.tag);
        }
    }
}