using UnityEngine;
using System;
using System.Collections;

//Written by Henry
//Is the most basic enemy movement. 
public class BasicEnemyMovement : MonoBehaviour {

    public Rigidbody enemy_RB;
    public float enemy_Speed = 25.0f;
    public Vector3 moving_Direction;
    public GameObject spawner;
    
    Vector3 tunnel_Speed;
    GameObject enemy;
    GameObject current_Tunnel;
    GameObject current_Tunnel_End;

    //Use this for initialization
    void Start()
    {
        enemy = gameObject;
        enemy_RB = GetComponent<Rigidbody>();
        spawner = GameObject.Find("Spawner");
        moving_Direction = Vector3.back * enemy_Speed;
    }

    // Update is called once per frame, and checks for conditions for FixedUpdate. 
    void Update()
    {
        //Always checks to see what type of tunnel it's in.
        if (current_Tunnel != null)
        {
            change_Tunnel_Direction(current_Tunnel.name);
        }

        if (check_Enemy_Active())
        {

        }
    }

    //Move's the object's rigidbody using data checked by Update.
    void FixedUpdate()
    {
        if (check_Enemy_Active())
        {
            
        }
        else
        {
            enemy_RB.velocity = moving_Direction;
            enemy.transform.position += tunnel_Speed;
        }

    }


    //(PUBLIC ACCESS FUNCTIONS)
    //Set's tunnel to current_Tunnel. This alter's which direction the ship points. 
    public void set_Tunnel_Type(GameObject tunnel)
    {
        current_Tunnel = tunnel;
    }

    //Set's the enemy's speed. For possible speed alterations.
    public void set_Enemy_Speed(float new_Speed)
    {
        enemy_Speed = new_Speed;
    }

    //Parses the "(Clone)" extension off of object names. 
    public string parse_Out_Clone(string object_Name)
    {
        string[] clone_Name = { "(Clone)" };
        string[] result = object_Name.Split(clone_Name, StringSplitOptions.None);
        return result[0];
    }


    //(OBJECT ALTERING FUNCTIONS)
    //Takes the name of a Field type, and change's the object's direction.
    void change_Tunnel_Direction(string tunnel_Case)   
    {
        string tunnel_Case_Parsed = parse_Out_Clone(tunnel_Case);
        float constant_X = 90.0f;

        switch (tunnel_Case_Parsed)
        {
            case "Field1":
                current_Tunnel = GameObject.Find(tunnel_Case);
                enemy_RB.rotation = (Quaternion.Euler(constant_X, 0, 0));
                break;
            case "Field2":
                current_Tunnel = GameObject.Find(tunnel_Case);
                enemy_RB.rotation = (Quaternion.Euler(constant_X, 0, 0));
                break;
            case "StarterField":
                current_Tunnel = GameObject.Find(tunnel_Case);
                enemy_RB.rotation = (Quaternion.Euler(constant_X, 0, 0));
                break;
        }

        tunnel_Speed = environmentMovement.movingSpeed;
        current_Tunnel_End = GameObject.Find(tunnel_Case+"/colliderEnd");
        Vector3 new_Direction = current_Tunnel.transform.position - current_Tunnel_End.transform.position;
        moving_Direction = new_Direction.normalized * enemy_Speed;
    }


    //(CHECK FUNCTIONS)
    //Checks for enemy's active status.
    bool check_Enemy_Active()
    {
        return (enemy.tag == "Enemy_Active");
    }
}
