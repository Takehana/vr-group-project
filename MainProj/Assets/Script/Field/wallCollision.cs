using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//not used
public class wallCollision : MonoBehaviour
{
    public float force;

    void OnTriggerEnter(Collider collider)
    {
        //bounce off the object upon colliding
        if (collider.gameObject.tag == "Enemy" ||
            collider.gameObject.tag == "Enemy_Active")
        {
            Vector3 player_pos = collider.transform.position;
            Vector3 wall_pos = transform.position;

            Vector3 pulse_direction = new Vector3(player_pos.x - wall_pos.x
                , player_pos.y - wall_pos.y, 0);

            Rigidbody body = collider.GetComponent<Rigidbody>();
            body.AddForce(pulse_direction * force, ForceMode.Impulse);

        }
    }
}