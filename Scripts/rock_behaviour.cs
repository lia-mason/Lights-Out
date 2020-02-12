using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_behaviour : MonoBehaviour
/**
 * Script moves objects across screen and destroys them out of sight
 * Can be used on any game object
 * To speed up movement, update speed in this script and in bg movement script
 */
{
    public float speed = 8.0f;
    private float screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = 0 - Camera.main.orthographicSize; //Left bound of screen
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        
    }
    void Update()
    {
        if (transform.position.x <  screenBounds * 3) //When rock is out of bounds destroy the clone
        {
            Destroy(this.gameObject);
        }
    }
}
