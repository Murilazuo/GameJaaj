using UnityEngine;
using System;

[DefaultExecutionOrder(-1)]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float life;
    public float points = 0;
    [SerializeField] private float[] pointsToNextUpgrade;
    public float maxLife;
    public static PlayerManager instance;
    [SerializeField] BarUi lifeUi, pointsUi;
    public int level;
    public bool canUpgrade = false;

    public static Action OnUpgrade;
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

        if (!canUpgrade)
        {
            if (damage < 0)
            {
                points += damage * -1;
            }
            if(level > pointsToNextUpgrade.Length-1)
            {
                if (points >= pointsToNextUpgrade[pointsToNextUpgrade.Length]) ;
            }
            else if (points >= pointsToNextUpgrade[level])
            {
                Upgrade();
            }
        }
        float maxPoints = pointsToNextUpgrade[pointsToNextUpgrade.Length - 1];
        if(level < pointsToNextUpgrade.Length)
        {
            maxPoints = pointsToNextUpgrade[level];
        }
        pointsUi.SetBar(points, maxPoints);
    }

    private void Upgrade()
    {
        
        OnUpgrade?.Invoke();
        canUpgrade = true;
        points = pointsToNextUpgrade[level];
    }

    private void GameOver()
    {

    }

    
}
