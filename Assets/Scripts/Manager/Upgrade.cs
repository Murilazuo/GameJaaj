using UnityEngine;
using UnityEngine.UI;


public class Upgrade : MonoBehaviour
{
    PlayerManager playerManager;
    MoveSkate moveSkate;
    GameManager gameManager;

    [SerializeField] float lifeToAdd, rotationSpeedToSubtract,rotationSpeedToAdd, maxSpeedToAdd, accererationToAdd, timeToAdd;
    private void Start()
    {
        playerManager = PlayerManager.instance;
        gameManager = GameManager.instance;
        moveSkate = playerManager.GetComponent<MoveSkate>();
    }
    public void UpgradeLife()
    {
        playerManager.maxLife += lifeToAdd;
        playerManager.SetLife(lifeToAdd);
        moveSkate.rotationForce -= rotationSpeedToSubtract;
    }
    public void UpgradeControl()
    {
        moveSkate.rotationForce += rotationSpeedToAdd;
    }
    public void UpgradeMaxSpeed()
    {
        moveSkate.maxSpeed += maxSpeedToAdd;
    }
    public void UpgradeAccereration()
    {
        moveSkate.accereration += accererationToAdd;
    }

    public void UpgradeTimer()
    {
        gameManager.time += timeToAdd;
    }
    public void UpgradeLifeOrb(Button button)
    {
        button.interactable = false;
    }
    public void UpgradeAntibiotic(Button button)
    {
        button.interactable = false;

    }
}

