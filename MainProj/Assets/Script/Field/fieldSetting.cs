using UnityEngine;
using System.Collections;

//not used
public class fieldSetting : MonoBehaviour
{
    System.Random rng = new System.Random();
    float tunnelLength = 128f;
    float wallSize = 8f;
    float wallCenterToSurface = 4f;

    //main method that builds the environment with objects as parameter
    public void BuildField(GameObject horizontal, GameObject vertical
        , GameObject wallBlock, int spawnRate, int density
        , float x_offsetRate, float y_offsetRate)
    {
        float wallGrid = 0;
        float obstacleGrid = 0;
        float x_offset = 0;
        float y_offset = 0;

        //slightly offset z starting position to avoid collision
        for (float z_pos = 2; z_pos <= tunnelLength - wallCenterToSurface
            ; z_pos++)
        {
            //current x, y offset position
            x_offset = x_offsetRate * z_pos;
            y_offset = y_offsetRate * z_pos;

            //build wall on current xy plane
            wallGrid = (z_pos + wallCenterToSurface) % wallSize;
            if (wallGrid == 0)
                OuterWall(wallBlock, z_pos, x_offset, y_offset);
            
            //build obstacle on current xy plane
            obstacleGrid = z_pos % density;
            if (obstacleGrid== 0)
            {
                //if( !FrontalWall(wallBlock, spawnRate, z_pos, x_offset, y_offset))
                    Obstacle(horizontal, vertical, spawnRate, density
                        , z_pos, x_offset, y_offset);
            }
        }
    }


    void Obstacle(GameObject horizontal, GameObject vertical
        , int spawnRate, int density
        , float z_pos, float x_offset, float y_offset)
    {
        int randSpawn = 0;

        for (float y_pos = -8; y_pos <= 8; y_pos = y_pos + density)
        {
            randSpawn = rng.Next(1, 101);
            if (randSpawn <= spawnRate)
            {
                double randLenngth = rng.NextDouble() * 16;
                float x_pos = (float)randLenngth - 20;
                GenerateObstacle(horizontal, x_pos + x_offset
                    , y_pos + y_offset, z_pos);
            }

            randSpawn = rng.Next(1, 101);
            if (randSpawn <= spawnRate)
            {
                double randLenngth = rng.NextDouble() * 16;
                float x_pos = (float)randLenngth + 4;
                GenerateObstacle(horizontal, x_pos + x_offset
                    , y_pos + y_offset, z_pos);
            }
        }

        for (float x_pos = -8; x_pos <= 8; x_pos = x_pos + density)
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

    bool FrontalWall(GameObject block, int spawnRate, float z_pos
        , float x_offset, float y_offset)
    {
        int rand = rng.Next(1, 101);
        if (rand <= spawnRate / 3)
        {
            int hole_pos = rng.Next(1, 5) * 2;
            int hole = 1;
            for (float x_pos = -8; x_pos <= 8; x_pos = x_pos + 8)
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
    }

    void OuterWall(GameObject block, float z_pos, float x_offset, float y_offset)
    {
        for (float y_pos = -8; y_pos <= 8; y_pos = y_pos + 8)
        {
            double randLength = rng.NextDouble() * 4;
            float x_pos = (float)randLength - 16;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
            randLength = rng.NextDouble() * 4;
            x_pos = (float)randLength + 12;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
        }

        for (float x_pos = -8; x_pos <= 8; x_pos = x_pos + 8)
        {
            double randLenngth = -rng.NextDouble() * 4;
            float y_pos = (float)randLenngth + 16;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
            randLenngth = -rng.NextDouble() * 4;
            y_pos = (float)randLenngth - 12;
            GenerateWall(block, x_pos + x_offset
                , y_pos + y_offset, z_pos);
        }
    }

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
