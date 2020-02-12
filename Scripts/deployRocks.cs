using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployRocks : MonoBehaviour
{
    public GameObject rockPrefab; //Object being cloned
    private float respawnTime; //Distance between objects
    private float screenBounds;
    public float timeRangeA = 1f;
    public float timeRangeB = 2f;
    private float rockSizeY; //Height of object
    private float rockPosY; //Position of center of object on Y axis
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = 0 - Camera.main.orthographicSize; //Left Edge of Screen on X axis
        StartCoroutine(rocksWave());
    }

    private void spawnRocksGround()
    {

        GameObject rock = Instantiate(rockPrefab) as GameObject; //Creates clone
        float rockSizeY = Random.Range(0.4f, 1.5f);
        //Sets position based off height so bottom of object is always in same Y position
        if (rockSizeY >= 0.88)
            rockPosY = -2.8f + (rockSizeY - .88f);
        else
        rockPosY = -2.8f - (.88f - rockSizeY);

        rock.transform.position = new Vector2(screenBounds * -3, rockPosY); //set position
        rock.transform.localScale = new Vector2(Random.Range(0.2f, 0.8f), rockSizeY); //set size
        //To create random 
    }

    
    IEnumerator rocksWave()
    {
        while (true)
        {
            respawnTime = Random.Range(timeRangeA, timeRangeB);
            yield return new WaitForSeconds(respawnTime);
            spawnRocksGround();
        }
    }
}
