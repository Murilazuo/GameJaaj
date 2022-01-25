using UnityEngine;
using UnityEngine.UI;


public class Upgrade : MonoBehaviour
{
    PlayerManager playerManager;
    MoveSkate moveSkate;
    GameManager gameManager;
    GameObject upgradePanel;

    [SerializeField] float lifeToAdd, rotationSpeedToSubtract,
    rotationSpeedToAdd, maxSpeedToAdd, accererationToAdd, timeToAdd;
    [SerializeField] int orbPercentageToAdd;
    private void Start()
    {
        playerManager = PlayerManager.instance;
        gameManager = GameManager.instance;
        moveSkate = playerManager.GetComponent<MoveSkate>();

        upgradePanel = transform.GetChild(0).gameObject;
        upgradePanel.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerManager.OnUpgrade += OpenUpgrade;
    }
    private void OnDisable()
    {
        PlayerManager.OnUpgrade -= OpenUpgrade;
    }
    void OpenUpgrade()
    {
        upgradePanel.SetActive(true);
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
        LifeOrbController.AddPercentage(orbPercentageToAdd);
        button.interactable = false;
    }
    public void UpgradeAntibiotic(Button button)
    {
        button.interactable = false;
    }
    public void ResetPlayerPoint()
    {
        playerManager.canUpgrade = false;
        playerManager.points = 0;
    }
}

