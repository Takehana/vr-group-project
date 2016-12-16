using UnityEngine;
using System.Collections;
using System;

//Written by Henry
public class EnemyMovement : MonoBehaviour {

    public Rigidbody enemy_Rigid_Body;
    public float enemy_Speed = 500.0f;
    public ArrayList movement_Queue;

    // Use this for initialization
    void Start () {
        enemy_Rigid_Body = GetComponent<Rigidbody>();
        enemy_Rigid_Body.velocity = Vector3.back * enemy_Speed;
        movement_Queue = new ArrayList();
    }

	// Update is called once per frame
    // Local functions act as AI behavior control
	void Update() {
       
    }

    //Checks for conditions that are to be updated in the update function.
    //When conditions are met, this is where rigidbody movements should be used.
    void FixedUpdate()
    {
        while (movement_Queue.Count == 0)
        {
            enemy_Rigid_Body.velocity = Vector3.back * enemy_Speed;
        }

        while (movement_Queue.Count != 0)
        {
            var current_Action = (Action_Info<string,float,Quaternion>)movement_Queue[0];
            perform_Action(current_Action);
            //movement_Queue.Remove(current_Action);
        }
    }



    public void queue_Action(Action_Info<string, float, Quaternion> new_Action)
    {
        movement_Queue.Add(new_Action);
    }

    void perform_Action(Action_Info<string, float, Quaternion> new_Action)
    {
        Vector3 enemy_Velocity = enemy_Rigid_Body.velocity;
        Quaternion deltaRotation = Quaternion.Euler(enemy_Velocity * Time.deltaTime/new_Action.action_Time);
        enemy_Rigid_Body.MoveRotation(enemy_Rigid_Body.rotation * deltaRotation);
    }

    //Updates player's location
    //void update_Player_Position()
    //{
    //    player_Position = GameObject.Find("player").transform.position;
    //}

    //ENEMY SHIP BEHAVIOR CHECKS
    //Works as true/false checks for behavior conditions


    //Checks to see if the enemy player is in range of player
    //bool player_In_Range(Vector3 player_Position)
    //{
    //    return (Vector3.Distance(player_Position, transform.position) < 300);
    //}

    //Checks to see if an action that takes prescedense over other behaviors
    //is triggered.
    //bool action_Triggered()
    //{
    //    return action_Trigger;
    //}

    //Checks to see if ship has held it's velocity for a set ammount of time
    //and returns false when time is up.
    //bool hold_Velocity(float command_Time)
    //{
    //    if (action_Time == 0)
    //    {
    //        print(transform.name + ": Holding velocity " + enemy_Rigid_Body.velocity
    //        + "for" + command_Time);
    //    }
    //    if (action_Time < command_Time)
    //    {
    //        action_Time += Time.deltaTime;
    //        return true;
    //    }
    //    else
    //    {
    //        action_Time = 0;
    //        return false;
    //    }
    //}

    //ENEMY SHIP BEHAVIOR ACTIONS
    //Usually ends with actually modifying the placement of the ship

    //An action where the enemy ship where charge at the player.
    //void charge_At_Player(Vector3 player_Position)
    //{
    //    print(transform.name + ": Charging at Player.");
    //    Vector3 towards_Player = player_Position - transform.position;
    //    change_Velocity(towards_Player * 500.0f);
    //}

    //Stops the enemy ship from moving at all, and takes a stationary position.
    //void halt_Position()
    //{
    //    print(transform.name + ": Halting position.");
    //    Vector3 stop_Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    //    change_Velocity(stop_Velocity);
    //    action_Trigger = true;
    //}

}

public class Action_Info<T1, T2, T3>
{
    public string action_Name;
    public float action_Time;
    public Quaternion action_Rotation;

    public Action_Info(string action_Name, float action_Time, Quaternion
        action_Rotation)
    {
        this.action_Name = action_Name;
        this.action_Time = action_Time;
        this.action_Rotation = action_Rotation;
    }
}
