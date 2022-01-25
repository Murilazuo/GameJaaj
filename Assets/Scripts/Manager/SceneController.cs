using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToScene(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
