
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string scene;
    public void NextScene()
    {
        SceneManager.LoadScene(scene);
    }
}
