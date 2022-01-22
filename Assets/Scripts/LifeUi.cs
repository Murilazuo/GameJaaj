using UnityEngine;
using UnityEngine.UI;

public class LifeUi : MonoBehaviour
{
    Image lifeBar;
    public static LifeUi lifeUi;
    private void Awake()
    {
        lifeUi = this;
    }
    void Start()
    {
        lifeBar = GetComponent<Image>();
    }

    public void SetLifeBar(float life, float maxLife)
    {
        lifeBar.fillAmount = life / maxLife;
    }
}
