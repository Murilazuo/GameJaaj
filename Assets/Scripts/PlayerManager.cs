using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life, maxLife, score = 0, points = 0, pointsToNextUpgrade;
    public static PlayerManager instance;
    [SerializeField] BarUi lifeUi, pointsUi;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        life = maxLife;

        lifeUi.SetBar(life,maxLife);
        pointsUi.SetBar(points, pointsToNextUpgrade);
    }
    internal void TakeHit(float damage)
    {
        life -= damage;

        if(life <= 0)
        {
            life = 0;
            lifeUi.SetBar(life, maxLife);

            GameOver();
            return;
        }

        lifeUi.SetBar(life, maxLife);

        points += damage;
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
