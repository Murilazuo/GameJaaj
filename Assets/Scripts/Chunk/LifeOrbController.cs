using UnityEngine;

public class LifeOrbController : MonoBehaviour
{
    [SerializeField] static float lifeSpawnPercentage = 5;
    [SerializeField] static float timeSpawnPercentage = 10;
    [SerializeField] GameObject[] lifeOrbs;
    [SerializeField] GameObject[] timeOrbs;


    void Start()
    {
        foreach(GameObject orb in lifeOrbs)
        {
            orb.SetActive(false);
        }
        foreach (GameObject orb in timeOrbs)
        {
            orb.SetActive(false);
        }
    }

    private void OnEnable()
    {
        int random = Random.Range(0, 100);
        float percentage = lifeSpawnPercentage;
        
        if(random <= percentage)
        {
            SpawnOrb(lifeOrbs);
        }

        random = Random.Range(0, 100);
        percentage = timeSpawnPercentage;

        if (random <= percentage)
        {
            SpawnOrb(timeOrbs);
        }


    }
    void SpawnOrb(GameObject[] orb)
    {
        int index = Random.Range(0, orb.Length);

        orb[index].SetActive(true);
    }
    public static void AddPercentage(int percentage)
    {
        lifeSpawnPercentage += percentage;
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
