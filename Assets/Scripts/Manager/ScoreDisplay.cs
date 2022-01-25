using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    ScoreCounter scoreCounter;
    Text text;
    void Start()
    {
        scoreCounter = PlayerManager.instance.GetComponent<ScoreCounter>();
        text = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        text.text = Mathf.Round(scoreCounter.score).ToString();
    }
}
