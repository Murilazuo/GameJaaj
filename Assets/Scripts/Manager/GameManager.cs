using UnityEngine;

[DefaultExecutionOrder(-2)]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int[] antibioticPercentage;

    private void Awake()
    {
        instance = this;
    }
}
