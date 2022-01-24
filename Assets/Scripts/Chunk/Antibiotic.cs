using UnityEngine;

[DefaultExecutionOrder(1)]
public class Antibiotic : MonoBehaviour
{
    [SerializeField] Color[] colorLevel;
    [SerializeField] private float[] damages;
    int level;
    SpriteRenderer spr;
    GameManager gameManager;

    public float damage;
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        gameManager = GameManager.instance;
    }
    private void OnEnable()
    {
        RandomLevel();
    }
    void SetLevel(int newLevel)
    {
        level = newLevel;

        spr.color = colorLevel[level];
        damage = damages[level];
    }

    void RandomLevel()
    {
        SetLevel(0);

        int randomPercentage = Random.Range(0, 100);

        if (randomPercentage < gameManager.antibioticPercentage[0])
        {
            SetLevel(0);
        }
        else if (randomPercentage < gameManager.antibioticPercentage[1])
        {
            SetLevel(1);
        }
        else
        {
            SetLevel(2);
        }
    }
}
