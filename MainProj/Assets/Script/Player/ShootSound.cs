using UnityEngine;
using System.Collections;

public class ShootSound : MonoBehaviour
{

    // Whenever the mouse is clicked, a laser sound is heard
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0"))
        {
            AudioSource sound = GetComponent<AudioSource>();
            sound.volume = .2f;
            sound.Play();
        }
    }
}
