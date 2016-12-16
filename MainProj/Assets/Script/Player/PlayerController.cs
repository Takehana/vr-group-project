using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

    void Update()
    {
        if (scoreKeeper.time <= scoreKeeper.startDelay)
            return;
        // Player movement control
        float xAxis = transform.FindChild("Main Camera").transform.rotation[0];
        float yAxis = transform.FindChild("Main Camera").transform.rotation[1];
        transform.position += new Vector3(0, 1, 0) * xAxis * -speed * Time.deltaTime;
        transform.position += new Vector3(1, 0, 0) * yAxis * speed * Time.deltaTime;
    }

}
