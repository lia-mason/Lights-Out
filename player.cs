using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public enum Keys { };
    Rigidbody2D rb;
    public float speed = 3f;
    float move = 1;
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
    }
}
