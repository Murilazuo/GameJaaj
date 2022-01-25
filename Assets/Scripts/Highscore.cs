using UnityEngine;
using UnityEngine.UI;
public class Highscore : MonoBehaviour
{
    public static int highscore = 0;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = highscore.ToString();
    }
    public static void CheckHighscore(int newScore)
    {
        if(newScore > highscore)
        {
            highscore = newScore;
        }
    }
}
