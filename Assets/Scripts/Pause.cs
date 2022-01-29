using UnityEngine;

public class Pause : MonoBehaviour
{
    bool pause;
    [SerializeField]GameObject pausePanel;
    private void Start()
    {
        UnPause();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                UnPause();
            }
            else if(Time.timeScale == 1){

                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pause = true;
        pausePanel.SetActive(true);

        Time.timeScale = 0;
    }
    public void UnPause()
    {
        pause = false;
        pausePanel.SetActive(false);

        Time.timeScale = 1;
    }

}
