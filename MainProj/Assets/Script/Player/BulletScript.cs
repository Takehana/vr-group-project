using UnityEngine;
using System.Collections;


//Geoffrey Herz


//Creates a bullet that fires from a bulletEmmiter and speeds off forward. 
//Drag this script onto a bulletEmmiter inside the scene. Drag a prefab of the bullet onto the script. 
//The bullet emmiter's blue axis points the direction of the bullet fire. 
//Bullet speed changes the speed that the bullet fires. 
//bulletExistanceTimer stats how long the bullet will last in seconds. 
public class BulletScript : MonoBehaviour {

    public GameObject bulletEmitter;
    public GameObject bullet;
    public float bulletSpeed = 25000f;
    public float bulletExistanceTimer = 3.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0"))
        {

            GameObject bullet = (GameObject)Instantiate(this.bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);

            //Commented out snippet can be used to fix any rotation issues (if we're using another bullet model then a sphere.) 
            //bullet.transform.Rotate(Vector3.left * 90);
            bullet.transform.parent = transform.parent;
            Rigidbody bulletRigidBody = bullet.GetComponent<Rigidbody>();
            bulletRigidBody.AddForce(transform.forward * bulletSpeed);
            Destroy(bullet, bulletExistanceTimer);
        }
    }
}
