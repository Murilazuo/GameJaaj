using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life, maxLife, score = 0, points = 0, pointsToNextUpgrade;
    public static PlayerManager instance;

    LifeUi lifeUi;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        lifeUi = LifeUi.lifeUi;
        life = maxLife;

        lifeUi.SetLifeBar(life,maxLife);
    }
    internal void TakeHit(float damage)
    {
        life -= damage;

        if(life <= 0)
        {
            life = 0;
            lifeUi.SetLifeBar(life, maxLife);

            GameOver();
            return;
        }
        lifeUi.SetLifeBar(life, maxLife);

        points += damage; 

        if(points >= pointsToNextUpgrade)
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
