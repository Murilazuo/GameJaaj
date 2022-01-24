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
        if(Vector2.Distance(playerTransform.position,transform.position) < distanceToSpawn)
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
        chunk = Instantiate(chunksToSpawn[Random.Range(0, chunksToSpawn.Length - 1)], new Vector2( 
        transform.position.x-10,transform.position.y+10), Quaternion.identity, transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,distanceToSpawn);
    }
}
