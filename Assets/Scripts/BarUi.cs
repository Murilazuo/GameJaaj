using UnityEngine;
using UnityEngine.UI;

public class BarUi : MonoBehaviour
{
    Image barImage;
    
    void Start()
    {
        barImage = GetComponent<Image>();
    }

    public void SetBar(float value, float maxValue)
    {
        barImage.fillAmount = value / maxValue;
    }
}
