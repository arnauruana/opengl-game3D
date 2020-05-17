using UnityEngine;


public class Pause : MonoBehaviour
{
    private bool paused;

    public GameObject gameObject;
    public GameObject gameOver;
    private SceneSwitcher sceneSwitcher;

    void Start()
    {
        this.paused = false;
        this.sceneSwitcher = GameObject.FindObjectOfType<SceneSwitcher>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.toggle();
        }
    }

    private void toggle()
    {
        if (this.gameOver.activeSelf) return;

        if (this.paused)
        {
            this.resumeGame();
        }
        else
        {
            this.pauseGame();
        }
    }

    private void pauseGame()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        this.paused = true;
    }

    private void resumeGame()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
        this.paused = false;
    }

    public void continuePressed()
    {
        this.resumeGame();
    }

    public void restartPressed()
    {
        Time.timeScale = 1;
        this.sceneSwitcher.reloadScene();
    }

    public void exitPressed()
    {
        Time.timeScale = 1;
        this.sceneSwitcher.switchToScene("Menu");
    }
}
