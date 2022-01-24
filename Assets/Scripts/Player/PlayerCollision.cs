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
                playerManager.SetLife(-collision.GetComponent<Antibiotic>().damage);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "LifeOrb":
                playerManager.SetLife(collision.GetComponent<LifeOrb>().lifeToAdd);
                collision.gameObject.SetActive(false);
                break;
        }
    }
}
