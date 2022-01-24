using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameManager : MonoBehaviour
{
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
            EndTime();
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
    public void EndTime()
    {

    }
}
