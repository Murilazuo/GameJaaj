using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string newScene;
    public void GoToScene(string scene)
    {
        FindObjectOfType<Fade>().ChangeFade();
        Time.timeScale = 1;
        newScene = scene;
        Invoke(nameof(NewScene),1f);
    }
    void NewScene()
    {
        SceneManager.LoadScene(newScene);
    }
}
