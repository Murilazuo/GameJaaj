using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] float timeToAdd;
    PlayerManager playerManager;
    MoveSkate moveSkate;

    GameManager gameManager;

    Animator barAnim;

    SoundManager soundManager;
    public int lifeOrb, timeOrb;
    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        gameManager = GameManager.instance;
        moveSkate = playerManager.GetComponent<MoveSkate>();
        soundManager = SoundManager.soundManager;
        barAnim = playerManager.pointsUi.GetComponent<Animator>();
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
        Orb orb = null;

        switch (collision.tag)
        {
            case "LifeOrb":
                soundManager.PlaySound("Bite");
                soundManager.PlaySound("Heal");
                orb = collision.GetComponent<Orb>();

                orb.Collect();
                playerManager.SetLife(orb.lifeToAdd);
                lifeOrb++;
                break;
            case "TimeOrb":
                soundManager.PlaySound("Bite");
                soundManager.PlaySound("GainTime");

                orb = collision.GetComponent<Orb>();
                gameManager.time += orb.lifeToAdd;
                orb.Collect();
                timeOrb++;
                break;
            case "Antibiotic":
                moveSkate.inAntibiotic = true;
                barAnim.SetBool("Evolve", true);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "Antibiotic":
                moveSkate.inAntibiotic = false;
                barAnim.SetBool("Evolve", false);
                soundManager.StopSound("WalkAntibiotic");
                break;
        }
    }
}
