using UnityEngine;

public class Fade : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ChangeFade()
    {
        anim.SetTrigger("Fade");
    }
}
