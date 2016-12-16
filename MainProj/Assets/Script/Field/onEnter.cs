using UnityEngine;
using System.Collections;

//by Shao
public class onEnter : MonoBehaviour
{
    public GameObject nextField;
    public GameObject emptyField;
    public static int counter = 0;

    //upon entering generate next segment of the field
    void OnTriggerEnter(Collider collider)
    {
        //print(collider);
        if (collider.gameObject.name == "player")
        {
            //on every 5th field reset the obstacle spawn rate
            //and generate a no obstacle segment
            if (counter == 5)
            {
                SpawnNextSection(emptyField);
                difficultySettings.spawnRate = 10;
                counter = 0;
            }
            else
            {
                SpawnNextSection(nextField);
                counter++;
            }
        }
            
    }

    //instantiate next segment
    public void SpawnNextSection(GameObject tunnel)
    {
        GameObject nextSection = Instantiate(tunnel);
        nextSection.transform.position = transform.FindChild("colliderEnd").transform.position;
    }
}
