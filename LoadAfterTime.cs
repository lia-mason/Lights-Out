
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadAfterTime : MonoBehaviour
{
    [SerializeField]
    private float loadingDelay = 10f;
    [SerializeField]
    private string loadScene;
    private float timeElapsed; 


    // Update is called once per frame
    private void Update()
    {
        timeElapsed += Time.deltaTime; 
        if (timeElapsed > loadingDelay)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(loadScene); 
        }
    }
}
