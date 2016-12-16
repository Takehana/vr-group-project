// Gabriel Larwood

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public float timeTillNextLevel = 5.0f;
    public bool timer = false;

    // Update is called once per frame
    void Update()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex == 1 & timer == true)
        {
            timeTillNextLevel -= Time.deltaTime;
            if (timeTillNextLevel <= 0)
            {
                LoadNextScene();
            }
        }
    }

    public void GameOver()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
    public void LoadPreviousLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex - 1);
    }
}
