using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life, maxLife, score = 0, points = 0, pointsToNextUpgrade;


    private void Start()
    {
        life = maxLife;
    }
    internal void TakeHit(float damage)
    {
        life -= damage;

        if(life <= 0)
        {
            life = 0;
            
            GameOver();
            return;
        }

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
