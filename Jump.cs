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

    private bool isGrounded = true;
    private bool onCeiling = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask platforms;
    public LayerMask ceiling;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigidbody2d.velocity = new Vector2(speed * 1, rigidbody2d.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platforms);
        onCeiling = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ceiling);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && onCeiling)
        {
            rigidbody2d.velocity = Vector2.down * jumpVelocity;
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

    

}
