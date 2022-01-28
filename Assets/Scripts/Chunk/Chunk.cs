using UnityEngine;
public class Chunk : MonoBehaviour
{
    [SerializeField] float distanceToSpawn;

    [SerializeField] GameObject[] chunksToSpawn;
    [SerializeField] GameObject chunk;

    [SerializeField] Transform playerTransform;

    bool chunkSpawn = false;
    bool chunkActive = false;
    private void Start()
    {
        playerTransform = PlayerManager.instance.transform;
    }
    private void Update()
    {
        if(Vector2.Distance(playerTransform.position,GetCenter()) < distanceToSpawn)
        {
            if (!chunkSpawn)
            {
                SpawnChunk();
            }
            else
            {
                chunk.SetActive(true);
                chunkActive = true;
            }
        }else if (chunkActive)
        {
            chunk.SetActive(false);
            chunkActive = false;
        }
    }
    void SpawnChunk()
    {
        chunkSpawn = true;
        int chunkIndex = Random.Range(0, chunksToSpawn.Length);
        if (chunkIndex == chunksToSpawn.Length) chunkIndex--;

        chunk = Instantiate(chunksToSpawn[chunkIndex], new Vector2( 
        transform.position.x-10,transform.position.y+10), Quaternion.identity, transform);
    }
    Vector2 GetCenter()
    {
        return new Vector2(transform.position.x + 10, transform.position.y - 10);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(GetCenter(),distanceToSpawn);
        Gizmos.DrawWireCube(GetCenter(), new Vector2(20, 20));
    }
}
