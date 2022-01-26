using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneController : MonoBehaviour
{
    string newScene;
    public void GoToScene(string scene)
    {
        FindObjectOfType<Fade>().ChangeFade("FadeIn");
        Time.timeScale = 1;
        newScene = scene;
        StartCoroutine(NewScene());
    }
    IEnumerator NewScene()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(newScene);
    }
    
}
