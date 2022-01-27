using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    [SerializeField] private string textBeforeScore, textBeforeLifeOrb, textBeforeTimeOrb, textBeforeLevel;
    [SerializeField] bool showScore;
    [SerializeField] bool showHealthOrbs;
    [SerializeField] bool showTimeOrbs;

    private void OnEnable()
    {
        if (showScore)
        {
            GetComponent<Text>().text = textBeforeScore +
            Mathf.Round(PlayerManager.instance.GetComponent<ScoreCounter>().score);
        }
        else if (showHealthOrbs)
        {
            GetComponent<Text>().text =
            textBeforeLifeOrb + "\n" +
            PlayerManager.instance.GetComponent<PlayerCollision>().lifeOrb.ToString(); 
        }
        else if (showTimeOrbs)
        {
            GetComponent<Text>().text =
            textBeforeTimeOrb + "\n" +
            PlayerManager.instance.GetComponent<PlayerCollision>().timeOrb.ToString();
        }
        else
        {
            GetComponent<Text>().text =
            textBeforeLevel + "\n" +
            FindObjectOfType<DisplayLevel>().GetLevel();
        }
    }
}
