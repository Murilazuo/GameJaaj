using UnityEngine;

public class Tutorial : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
