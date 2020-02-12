using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    private float screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = 0 - Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenBounds * 3)
        {
            Debug.Log("Out");
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }
    }
}
