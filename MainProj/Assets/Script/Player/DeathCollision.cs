using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathCollision : MonoBehaviour
{
    void OnStart()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            print(collision.gameObject.tag);
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

}