using UnityEngine;
using System.Collections;

//not used
public class moveCharacter : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        //onEnter.OnTriggerEnter();

    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.B))
        {
            transform.Translate(Vector3.back * speed);
        }

        transform.Translate(Vector3.forward * speed);
    }
}
