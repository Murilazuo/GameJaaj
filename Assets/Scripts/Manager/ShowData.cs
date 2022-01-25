using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    [SerializeField] private string textBeforeScore, textBeforeLifeOrb, textBeforeTimeOrb, textBeforeLevel;
    [SerializeField] bool showScore;

    private void OnEnable()
    {
        if (showScore)
        {
            GetComponent<Text>().text = textBeforeScore + 
            Mathf.Round(PlayerManager.instance.GetComponent<ScoreCounter>().score);
        }
        else
        {
            GetComponent<Text>().text =
            textBeforeLifeOrb + "\n" +
            PlayerManager.instance.GetComponent<PlayerCollision>().lifeOrb.ToString() + "\n\n" +
            textBeforeTimeOrb + "\n" +
            PlayerManager.instance.GetComponent<PlayerCollision>().timeOrb.ToString() + "\n\n" +
            textBeforeLevel + "\n" +
            PlayerManager.instance.level.ToString();
        }
    }
}
