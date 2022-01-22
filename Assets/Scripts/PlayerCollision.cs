using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerManager playerManager;
    private void Start()
    {
         playerManager = GetComponent<PlayerManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Antibiotic":
                playerManager.TakeHit(1);
                break;
        }
    }
}
