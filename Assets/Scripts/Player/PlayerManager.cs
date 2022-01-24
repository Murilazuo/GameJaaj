using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life, maxLife, score = 0, points = 0, pointsToNextUpgrade;
    public static PlayerManager instance;
    [SerializeField] BarUi lifeUi, pointsUi;
    public int level;
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

        pointsUi.SetBar(points, pointsToNextUpgrade);

        if (points >= pointsToNextUpgrade)
        {
            Upgrade(); 
            pointsToNextUpgrade *= 1.5f;
        }
    }

    private void Upgrade()
    {

    }

    private void GameOver()
    {

    }
}
