using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deploySpikes : MonoBehaviour
{
    public GameObject rockPrefab;
    private float respawnTime;
    public float timeRangeA = 1f;
    public float timeRangeB = 2f;
    private float screenBounds;
    private float rockSizeY;
    private float rockPosY;
    //BoxCollider2D floor;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = 0 - Camera.main.orthographicSize;
        StartCoroutine(rocksWave());
        //GameObject bg = GameObject.Find("bg");
        //floor = bg.GetComponent<BoxCollider2D>();

    }

    private void spawnRocksGround()
    {

        GameObject rock = Instantiate(rockPrefab) as GameObject;
        float rockSizeY = Random.Range(0.4f, 1.5f);
        if (rockSizeY >= 0.88)
            rockPosY = 3.5f - (rockSizeY - .88f);
        else
            rockPosY = 3.5f + (.88f - rockSizeY);

        rock.transform.position = new Vector2(screenBounds * -3, rockPosY);
        rock.transform.localScale = new Vector2(Random.Range(.2f, .8f), rockSizeY);
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
