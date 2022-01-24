using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] Vector2 arenaSize;
    [SerializeField] GameObject chunk;
    private void Start()
    {
        Transform playerTransform = PlayerManager.instance.transform;

        for (float x = 0; x < arenaSize.x * 20; x += 20)
        {
            for (float y = 0; y < arenaSize.y * 20; y += 20)
            {
                Vector3 positionToSpawn = new Vector2(x, y);
                if(playerTransform.position != positionToSpawn)
                {
                    Instantiate(chunk, positionToSpawn,Quaternion.identity);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 arenaRealSize = new Vector3(arenaSize.x * 20, arenaSize.y * 20);
        Gizmos.DrawWireCube(new Vector3(arenaRealSize.x / 2, arenaRealSize.y / 2), new Vector3(arenaRealSize.x, arenaRealSize.y));
    }
}
