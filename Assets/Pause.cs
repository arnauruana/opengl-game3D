using UnityEngine;


public class Pause : MonoBehaviour
{
    private SceneSwitcher sceneSwitcher;

    private void Start()
    {
        this.sceneSwitcher = GameObject.FindObjectOfType<SceneSwitcher>();
    }

    public void toggle()
    {
        if (this.gameObject.activeSelf)
        {
            this.resumeGame();
        }
        else
        {
            this.pauseGame();
        }
    }

    public void continuePressed()
    {
        this.resumeGame();
    }

    public void restartPressed()
    {
        this.sceneSwitcher.reloadScene();
    }

    public void exitPressed()
    {
        this.sceneSwitcher.switchToScene("Menu");
    }

    public void pauseGame()
    {
        // Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    private void resumeGame()
    {
        this.gameObject.SetActive(false);
        // Time.timeScale = 1;
    }
}
