using UnityEngine;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    Animator anim;
    public static Fade fade;
    private void Awake()
    {
        Time.timeScale = 1.0f;
        GetComponent<Image>().enabled = true;
        fade = this;
    }
    private void Start()
    {

        anim = GetComponent<Animator>();
        anim.SetTrigger("Fade");
    }
    public void ChangeFade(string fade)
    {
        anim.SetTrigger(fade);
    }
}
