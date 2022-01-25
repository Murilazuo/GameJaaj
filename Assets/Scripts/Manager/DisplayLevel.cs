using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
    Text text;
    int level;
    void Start()
    {
        text = GetComponent<Text>();
    }
    public void UpdateLevel()
    {
        level++;
        text.text = level.ToString();
    }
}
