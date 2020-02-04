using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]  private LayerMask platformMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    float speed = 3f;
    float jumpVelocity = 12f;
    public bool gravitySwitch = true;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded() && Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        if (IsGrounded() && Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2d.velocity = Vector2.down * jumpVelocity;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.right * -speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))

        {
            gravitySwitch = !gravitySwitch;
            if (gravitySwitch)
            {
                Physics2D.gravity = new Vector3(0, 9.81f, 0);
                transform.localRotation = Quaternion.Euler(180, 0, 0); 

            }
            else if (!(gravitySwitch)) 
            {
                Physics2D.gravity = new Vector3(0, -9.81f, 0);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }

        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, platformMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null; 
    }

}
