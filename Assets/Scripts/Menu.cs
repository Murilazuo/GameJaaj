using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    [DefaultExecutionOrder(3)]
public class Menu : MonoBehaviour
{
    bool play = false;
    Fade fade;

    SoundManager soundManager;
    private void Start()
    {
        fade = Fade.fade;

        soundManager = SoundManager.soundManager;
        soundManager.PlaySound("MusicMenu");
        soundManager.StopSound("Music");
    }
    public void SetVolume(Slider slider)
    {
        soundManager.SetVolumeFx(slider);
    }
    public void SetVolumeMusic(Slider slider)
    {
        soundManager.SetVolumeMusic(slider);
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
