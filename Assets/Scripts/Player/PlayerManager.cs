using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life, score = 0, points = 0, pointsToNextUpgrade;
    public float maxLife;
    public static PlayerManager instance;
    [SerializeField] BarUi lifeUi, pointsUi;
    public int level;
    bool canUpgrade = false;
    private void Awake()
    {
        instance = this;

        transform.position = new Vector2(Mathf.Round(transform.position.x / 20) * 20, 
            Mathf.Round(transform.position.y / 20) * 20);
    }
    private void Start()
    {
        life = maxLife;
        level = 0;
    }
    internal void SetLife(float damage)
    {
        life += damage;
        
        life = Mathf.Clamp(life, 0, maxLife);

        if(life == 0)
        {
            lifeUi.SetBar(life, maxLife);

            GameOver();
            return;
        }

        lifeUi.SetBar(life, maxLife);

        if(damage < 0)
        {
            points += damage * -1;
        }

        if (points >= pointsToNextUpgrade && !canUpgrade)
        {
            Upgrade(); 
        }
        pointsUi.SetBar(points, pointsToNextUpgrade);
    }

    private void Upgrade()
    {
        canUpgrade = true;
        pointsToNextUpgrade *= 1.5f;
        points = pointsToNextUpgrade;
    }

    private void GameOver()
    {

    }

    
}
