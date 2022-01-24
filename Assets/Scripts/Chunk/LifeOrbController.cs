using UnityEngine;

public class LifeOrbController : MonoBehaviour
{
    [SerializeField] static float spawnPercentage = 5;
    [SerializeField] GameObject[] lifeOrbs;
    void Start()
    {
        foreach(GameObject orb in lifeOrbs)
        {
            orb.SetActive(false);
        }
    }

    private void OnEnable()
    {
        int random = Random.Range(0, 100);
        float percentage = spawnPercentage;

        /*while(percentage > 100)
        {
            percentage -= 100;
            SpawnOrb();
        }*/
        
        if(random <= percentage)
        {
            SpawnOrb();
        }
    }
    void SpawnOrb()
    {
        int index = Random.Range(0, lifeOrbs.Length);

        lifeOrbs[index].SetActive(true);
    }
    public static void AddPercentage(int percentage)
    {
        spawnPercentage += percentage;
    }

    Vector2 GetCenter()
    {
        return new Vector2(transform.position.x + 10, transform.position.y - 10);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(GetCenter(), new Vector2(20, 20));
    }
}
