using UnityEngine;
using System.Collections.Generic;
public class LifeOrbController : MonoBehaviour
{
    [SerializeField] static float lifeSpawnPercentage = 30;
    [SerializeField] static float timeSpawnPercentage = 30;

    [SerializeField] List<Orb> lifeOrbs;
    [SerializeField] List<Orb> timeOrbs;

   
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
    void SpawnOrb(List<Orb> orb)
    {
        int index = Random.Range(0, orb.Count);

        if (index == orb.Count) index--;

        orb[index].Spawn();
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
