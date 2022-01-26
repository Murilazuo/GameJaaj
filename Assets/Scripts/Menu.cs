using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    bool play = false;
    Fade fade;
    private void Start()
    {
        fade = Fade.fade;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !play)
        {
            SoundManager.soundManager.PlaySound("Click");
            fade.ChangeFade("FadeIn");
            play = true;
            Invoke(nameof(Play),1f);
        }   
    }
    private void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
