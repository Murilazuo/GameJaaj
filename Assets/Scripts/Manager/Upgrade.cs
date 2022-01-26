using UnityEngine;
using UnityEngine.UI;


public class Upgrade : MonoBehaviour
{
    PlayerManager playerManager;
    MoveSkate moveSkate;
    GameManager gameManager;
    GameObject upgradePanel;
    SoundManager soundManager;

    [SerializeField] float lifeToAdd, rotationSpeedToSubtract,
    rotationSpeedToAdd, maxSpeedToAdd, accererationToAdd, timeToAdd;
    [SerializeField] int orbPercentageToAdd;
    private void Start()
    {
        playerManager = PlayerManager.instance;
        gameManager = GameManager.instance;
        soundManager = SoundManager.soundManager;
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
        soundManager.PlaySound("Heal");
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
        soundManager.PlaySound("GainTime");

        gameManager.time += timeToAdd;
    }
    public void UpgradeLifeOrb(Button button)
    {
        LifeOrbController.AddPercentage(orbPercentageToAdd);
        button.interactable = false;
    }
    public void ResetPlayerPoint()
    {
        soundManager.PlaySound("ClickUpgrade");
        Time.timeScale = 1;
        playerManager.canUpgrade = false;
        playerManager.points = 0;
    }
}

