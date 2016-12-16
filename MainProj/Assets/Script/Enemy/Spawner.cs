using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//Written by Henry
//Spawns 4 loaded GameObjects and dictates spawn times by
//by user input spawn rates. Default spawn rate is increments
//of 5. If a script is on an object spawned out of the spawner,
//the script can override the spawner's speed on the game object
//with it's own.

public class Spawner : MonoBehaviour
{
    System.Random rng = new System.Random();
    
    //public settings 
    //loaded enemy types
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    
    //Spawn rate of enemies. 
    //Enemies will spawn every "enemy#_Spawn_Rate" seconds.
    public float enemy1_Spawn_Rate;
    public float enemy2_Spawn_Rate;
    public float enemy3_Spawn_Rate;
    public float enemy4_Spawn_Rate;

    //Velocity direction of enemy spawning.
    public float enemy_Speed = -5.0f;
    public int x_Offset = 50;
    public int y_Offset = 50;
    float gameTime = 0.0f;
    float enemy1_SpawnTime = 5.0f;
    float enemy2_SpawnTime = 10.0f;
    float enemy3_SpawnTime = 15.0f;
    float enemy4_SpawnTime = 20.0f;

    private Dictionary<GameObject, Spawn_Info<float, float>> enemy_Dictionary =
        new Dictionary<GameObject, Spawn_Info<float, float>>();
    
    // Use this for initialization
    void Start()
    {
        setupDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        foreach(KeyValuePair<GameObject, Spawn_Info<float, float>> enemy in enemy_Dictionary)
        {
            if (gameTime > enemy.Value.spawn_Time && transform.tag == "Spawner")
            {   
                //Increments the next spawn time for current enemy by the spawnrate value.
                enemy.Value.spawn_Time += enemy.Value.spawnRate;

                GameObject spawned_Enemy = Instantiate(enemy.Key);

                //Find values for random offsets within box range
                float random_Offset_Number_X = rng.Next((x_Offset * -1), x_Offset);
                float random_Offset_Number_Y = rng.Next((y_Offset * -1), y_Offset);
                var offSetSpawn = new Vector3(transform.position.x +
                                    random_Offset_Number_X, transform.position.y + random_Offset_Number_Y,
                                    transform.position.z);
                //Check for good spawn location
                print(offSetSpawn);
                spawned_Enemy.transform.position = offSetSpawn;
            }
        }
    }

    //Sets up enemy dictionary by looking at the global fields.
    //Function allows for empty GameObject slots in the public
    //access. 
    void setupDictionary()
    {
        if (Enemy1 != null)
        {
            var enemy_1_info = new Spawn_Info<float, float>(enemy1_Spawn_Rate, enemy1_SpawnTime);
            enemy_Dictionary.Add(Enemy1, enemy_1_info);
            enemy1_SpawnTime += enemy1_Spawn_Rate;
        }
        if (Enemy2 != null)
        {
            var enemy_2_info = new Spawn_Info<float, float>(enemy2_Spawn_Rate, enemy2_SpawnTime);
            enemy_Dictionary.Add(Enemy2, enemy_2_info);
            enemy2_SpawnTime += enemy2_Spawn_Rate;
        }
        if (Enemy3 != null)
        {
            var enemy_3_info = new Spawn_Info<float, float>(enemy3_Spawn_Rate, enemy3_SpawnTime);
            enemy_Dictionary.Add(Enemy3, enemy_3_info);
            enemy3_SpawnTime += enemy3_Spawn_Rate;
        }
        if (Enemy4 != null)
        {
            var enemy_4_info = new Spawn_Info<float, float>(enemy4_Spawn_Rate, enemy4_SpawnTime);
            enemy_Dictionary.Add(Enemy4, enemy_4_info);
            enemy4_SpawnTime += enemy4_Spawn_Rate;
        }
    }

}

//Internal class type to store pairs of information
//Can be modified to include more data later down the road. 
internal class Spawn_Info<T1, T2>
{
    public float spawn_Time;
    public float spawnRate;

    public Spawn_Info(float enemy_Spawn_Rate, float enemy_Spawn_Time)
    {
        spawnRate = enemy_Spawn_Rate;
        spawn_Time = enemy_Spawn_Time;
    }

}