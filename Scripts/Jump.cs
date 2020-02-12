using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
   
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;

    private bool gravitySwitch = true;
    //Jumping Variables
    public float speed = 3f;
    public float jumpVelocity = 12f;
    public LayerMask platforms;
    public LayerMask ceiling;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();

    }

    
    //Checks if player is touching the ground
    private bool isGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,
            0f, Vector2.down, 1f, platforms);
        return raycastHit2d.collider != null;
    }
    //Checks if player is toucjing the ceiling
    private bool onCeiling()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size,
            0f, Vector2.up, 1f, ceiling);
        return raycastHit2d.collider != null;
    }

    private void Update()
    {
        //Jumps up if player is on ground, prevents jumping mid air
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
        //Jumps "down" if player is on ceiling, prevents jumping mid air
        if (Input.GetKeyDown(KeyCode.UpArrow) && onCeiling())
        {
            Debug.Log("ceiling");
            rigidbody2d.velocity = Vector2.down * jumpVelocity;
        }
        

        //Gravity Switch when space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))

        {
            if (gravitySwitch)
            {
                Physics2D.gravity = new Vector3(0, 9.81f, 0);
                transform.localRotation = Quaternion.Euler(180, 0, 0);
                gravitySwitch = false;

            }
            else if (!(gravitySwitch))
            {
                Physics2D.gravity = new Vector3(0, -9.81f, 0);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                gravitySwitch = true;
            }

        }

    }

    

}
