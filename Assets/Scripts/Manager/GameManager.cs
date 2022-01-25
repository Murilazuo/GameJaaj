using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public int[] antibioticPercentage;

    public static GameManager instance;

    public float time;
    
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        if(time <= 0)
        {
            time = 0;
            EndGame();
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    public void EndGame()
    {
        Highscore.CheckHighscore((int)PlayerManager.instance.GetComponent<ScoreCounter>().score);
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
