using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToAdd;
    PlayerManager playerManager;
    GameManager gameManager;
    public int lifeOrb, timeOrb;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        gameManager = GameManager.instance;
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
                playerManager.SetLife(collision.GetComponent<Orb>().lifeToAdd);
                collision.gameObject.SetActive(false);
                lifeOrb++;
                break;
            case "TimeOrb":
                gameManager.time += collision.GetComponent<Orb>().lifeToAdd;
                collision.gameObject.SetActive(false);
                timeOrb++;
                break;
        }
    }
}
