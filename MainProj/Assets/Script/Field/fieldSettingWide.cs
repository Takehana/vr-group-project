using UnityEngine;
using System.Collections;

//by Shao
public class fieldSettingWide : MonoBehaviour {

    System.Random rng = new System.Random();
    //geometry of objects
    float tunnelLength = 128f;
    float wallSize = 8f;
    float wallCenterToSurface = 4f;

    //geometry of field
    float y_max = 8;
    float y_min = -8;
    float x_min = -12;
    float x_max = 12;

    //build environment using the object in parameter
    public void BuildField(GameObject horizontal, GameObject vertical
        , GameObject wallBlock, int spawnRate, int density
        , float x_offsetRate, float y_offsetRate)
    {
        float wallGrid = 0;
        float obstacleGrid = 0;
        float x_offset = 0;
        float y_offset = 0;

        //loop through the length of the tunnel
        for (float z_pos = 2; z_pos <= tunnelLength - wallCenterToSurface
            ; z_pos++)
        {
            //cumulative offset on current z position
            x_offset = x_offsetRate * z_pos;
            y_offset = y_offsetRate * z_pos;

            //build wall on current xy plane
            wallGrid = (z_pos + 4) % 8;
            if (wallGrid == 0)
                OuterWall(wallBlock, z_pos, x_offset, y_offset);

            //build obstacle on current xy plane
            obstacleGrid = z_pos % density;
            if (obstacleGrid == 0)
                    Obstacle(horizontal, vertical, spawnRate, density
                        , z_pos, x_offset, y_offset);
        }
    }

    //build obstacle on a xy plane at z_pos away from start
    void Obstacle(GameObject horizontal, GameObject vertical
        , int spawnRate, int density
        , float z_pos, float x_offset, float y_offset)
    {
        int randSpawn = 0;

        for (float y_pos = y_min; y_pos <= y_max; y_pos = y_pos + density)
        {
            //position of obstacle on left wall with a range of random offset
            randSpawn = rng.Next(1, 101);
            if (randSpawn <= spawnRate)
            {
                double randLenngth = rng.NextDouble() * 16;
                float x_pos = (float)randLenngth - 24;
                GenerateObstacle(horizontal, x_pos + x_offset
                    , y_pos + y_offset, z_pos);
            }

            //right wall
            randSpawn = rng.Next(1, 101);
            if (randSpawn <= spawnRate)
            {
                double randLenngth = rng.NextDouble() * 16;
                float x_pos = (float)randLenngth + 8;
                GenerateObstacle(horizontal, x_pos + x_offset
                    , y_pos + y_offset, z_pos);
            }
        }

        //top or bottom wall
        for (float x_pos = -12; x_pos <= 12; x_pos = x_pos + density)
        {
            randSpawn = rng.Next(1, 101);
            if (randSpawn <= spawnRate)
            {
                double randLenngth = rng.NextDouble() * 40;
                float y_pos = (float)randLenngth - 20;
                GenerateObstacle(vertical, x_pos + x_offset
                    , y_pos + y_offset, z_pos);
            }
        }
    }

    /*bool FrontalWall(GameObject block, int spawnRate, float z_pos
        , float x_offset, float y_offset)
    {
        int rand = rng.Next(1, 101);
        if (rand <= spawnRate / 3)
        {
            int hole_pos = rng.Next(1, 5) * 2;
            int hole = 1;
            for (float x_pos = -12; x_pos < 12; x_pos = x_pos + 8)
            {
                for (float y_pos = -8; y_pos <= 8; y_pos = y_pos + 8)
                {
                    if (hole != 5 && hole != hole_pos)
                        GenerateWall(block, x_pos + x_offset
                            , y_pos + y_offset, z_pos);
                    hole++;
                }
            }
            return true;
        }
        return false;
    }*/

    //build walls on a xy plane at z_pos away from start
    void OuterWall(GameObject block, float z_pos, float x_offset, float y_offset)
    {
        //left and right wall with a range of random offset
        for (float y_pos = y_min; y_pos <= y_max; y_pos = y_pos + wallSize)
        {
            double randLength = rng.NextDouble() * wallCenterToSurface;
            float x_pos = (float)randLength + x_min - wallSize;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
            randLength = rng.NextDouble() * wallCenterToSurface;
            x_pos = x_max + wallSize - (float)randLength;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
        }

        //top and bottom wall with a range of random offset
        for (float x_pos = x_min; x_pos <= x_max; x_pos = x_pos + wallSize)
        {
            double randLenngth = rng.NextDouble() * wallCenterToSurface;
            float y_pos = y_max + wallSize - (float)randLenngth;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
            randLenngth = rng.NextDouble() * wallCenterToSurface;
            y_pos = y_min - wallSize + (float)randLenngth;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
        }
    }

    //instantiate object at specific coordinate
    void GenerateObstacle(GameObject pile, float x_pos, float y_pos, float z_pos)
    {
        GameObject obstacle = Instantiate(pile);
        obstacle.transform.position = transform.position + new Vector3(x_pos, y_pos, z_pos) * 10;
        obstacle.transform.parent = gameObject.transform;
        //Destroy(obstacle, destroyTime);
    }

    void GenerateWall(GameObject block, float x_pos, float y_pos, float z_pos)
    {
        GameObject wallBlock = Instantiate(block);
        wallBlock.transform.position = transform.position + new Vector3(x_pos, y_pos, z_pos) * 10;
        wallBlock.transform.parent = gameObject.transform;
        //Destroy(wallBlock, destroyTime);
    }
}
