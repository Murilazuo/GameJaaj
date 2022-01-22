using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerManager playerManager;
    private void Start()
    {
         playerManager = GetComponent<PlayerManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Antibiotic":
                playerManager.TakeHit(0.1f);
                break;
        }
    }
}
