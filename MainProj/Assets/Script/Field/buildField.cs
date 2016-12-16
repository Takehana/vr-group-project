using UnityEngine;
using System.Collections;

//by Shao
public class buildField : MonoBehaviour
{
    public fieldSettingWide fieldSetup;
    public GameObject horizontalPile;
    public GameObject verticalPile;
    public GameObject wallBlock;
    public int density;
    public static int spawnRate;
    public GameObject player;
    System.Random rng = new System.Random();

    // Use this for initialization
    void Start()
    {
        //position of the endCollider
        int x_pos;
        int y_pos;
        int z_pos = 1280;
        x_pos = rng.Next(-450, 450);
        y_pos = rng.Next(-450, 450);

        player = GameObject.Find("player");
        if (player.tag != "Player")
        {
            horizontalPile = new GameObject();
            verticalPile = new GameObject();
            x_pos = 0;
            y_pos = 0;
            player.tag = "Player";
        }

        transform.parent.FindChild("colliderEnd")
            .Translate(new Vector3(x_pos, y_pos, z_pos));

        //offset rae of the current random geometry
        float x_offsetRate = (float)x_pos / z_pos;
        float y_offsetRate = (float)y_pos / z_pos;

        /*Vector3 offset = 
            transform.parent.FindChild("colliderEnd").localPosition;

        float x_offsetRate = offset.x / offset.z;
        float y_offsetRate = offset.y / offset.z;*/

        //build environment along the current geometry
        fieldSetup.BuildField(horizontalPile, verticalPile, wallBlock
            , spawnRate, density, x_offsetRate, y_offsetRate);
    }
}
