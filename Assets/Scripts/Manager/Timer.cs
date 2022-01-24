using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    GameManager gameManager;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        gameManager = GameManager.instance;
    }
    void Update()
    {
        text.text = TimerConverter.ToSeconds(gameManager.time);
    }
}
