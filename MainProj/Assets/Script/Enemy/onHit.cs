using UnityEngine;
using System.Collections;

//by Shao & Gabe
public class onHit : MonoBehaviour {
    public float scoreEarned;
    public GameObject ExplosionPrefab;

    void OnTriggerEnter(Collider collider)
    {
        //print(collider);

        //enemy being hit by bullet
        if (collider.gameObject.name == "Bullet(Clone)")
        {
            //gain score, increment kill count
            scoreKeeper.score += scoreEarned/2;
            scoreKeeper.killCount += 1f/2;
            //print("bullet hit     "+ scoreKeeper.killCount);

            // Creates explosion
            Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
