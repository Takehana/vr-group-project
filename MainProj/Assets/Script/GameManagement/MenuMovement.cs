using UnityEngine;
using System.Collections;

public class MenuMovement : MonoBehaviour {

    public GameObject player;
    public GameObject ship1;
    public GameObject ship2;
    public Vector3 shipsMovingSpeed;
    public GameObject button;
    public float stoppingPoint;
    public Vector3 playerMovingSpeed;
    private int count = 0;

	// Update is called once per frame
	void Update () {

		// Controls the flying helecopter movement speed
        ship1.transform.Translate(shipsMovingSpeed);
        ship2.transform.Translate(shipsMovingSpeed);
        Vector3 vector = player.transform.position;

		// Determines when the player will stop moving and when the play game button will spawn
		if (stoppingPoint > vector.z) {
            transform.Translate(playerMovingSpeed);
        }
		if (stoppingPoint <= vector.z & count == 0) {
            Instantiate(button);
            count++;
        }
	}
}
