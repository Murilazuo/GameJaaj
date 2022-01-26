using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    bool play = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !play)
        {
            SoundManager.soundManager.PlaySound("fx");
            FindObjectOfType<Fade>().ChangeFade();
            play = true;
            Invoke(nameof(Play),1f);
        }   
    }
    private void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
