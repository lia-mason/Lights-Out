using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{

    Rigidbody2D rb;
    float speed = 5f;
    BoxCollider2D box2d;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask platforms;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platforms);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        { 
            rb.velocity = Vector2.up * 5f;
        }

    }
    
}
