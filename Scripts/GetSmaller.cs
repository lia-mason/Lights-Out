using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSmaller : MonoBehaviour
{

    bool small;

    // Start is called before the first frame update
    void Start()
    {
        small = false;
    }

    // Update is called once per frame
    void Update()
    {

        Transform size = GetComponent<Transform>();

        if (Input.GetKeyUp(KeyCode.V) && small == false)
        {
            size.localScale *= 0.5f;
            small = true;
            //change position ?
            //size.position *= 0.2f;
        }
        else if (Input.GetKeyUp(KeyCode.V) && small == true)
        {
            size.localScale *= 2f;
            small = false;
        }

    }
}