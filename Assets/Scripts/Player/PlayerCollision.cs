using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToAdd;
    PlayerManager playerManager;
    MoveSkate moveSkate;

    GameManager gameManager;

    SoundManager soundManager;
    public int lifeOrb, timeOrb;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        gameManager = GameManager.instance;
        moveSkate = playerManager.GetComponent<MoveSkate>();
        soundManager = SoundManager.soundManager;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Limit"))
        {
            moveSkate.speed = 0;
        }
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
                soundManager.PlaySound("Bite");
                soundManager.PlaySound("Heal");

                playerManager.SetLife(collision.GetComponent<Orb>().lifeToAdd);
                collision.gameObject.SetActive(false);
                lifeOrb++;
                break;
            case "TimeOrb":
                soundManager.PlaySound("Bite");
                soundManager.PlaySound("GainTime");

                gameManager.time += collision.GetComponent<Orb>().lifeToAdd;
                collision.gameObject.SetActive(false);
                timeOrb++;
                break;
            case "Antibiotic":
                moveSkate.inAntibiotic = true;
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Antibiotic":
                moveSkate.inAntibiotic = false;
                soundManager.StopSound("WalkAntibiotic");
                break;
        }
    }
}
