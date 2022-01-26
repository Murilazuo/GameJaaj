using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public int[] antibioticPercentage;

    public static GameManager instance;

    public float time;
    SoundManager soundManager;
    private void Awake()
    {
        instance = this;
        soundManager = SoundManager.soundManager;
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
    public void Click()
    {
        soundManager.PlaySound("Click");
    }
    public void EndGame()
    {
        Highscore.CheckHighscore((int)PlayerManager.instance.GetComponent<ScoreCounter>().score);
        gameOver.SetActive(true);
        Time.timeScale = 0;

        soundManager.StopSound("Walk");
        soundManager.StopSound("WalkAntibiotic");

    }
}
