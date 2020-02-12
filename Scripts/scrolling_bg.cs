using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling_bg : MonoBehaviour
{
    public float speed = 1f;
    public float clampPos; //Equal to end of entire background

    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newPos = Mathf.Repeat(Time.time * speed, clampPos);
        transform.position = startPos + Vector3.left * newPos;
    }
}
