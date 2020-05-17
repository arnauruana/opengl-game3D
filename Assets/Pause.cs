using UnityEngine;


public class Pause : MonoBehaviour
{
    private bool paused;

    public GameObject gameObject;
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

    public void toggle()
    {
        if (this.paused)
        {
            this.resumeGame();
        }
        else
        {
            this.pauseGame();
        }
    }

    public void pauseGame()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        this.paused = true;
    }

    public void resumeGame()
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
        this.sceneSwitcher.reloadScene();
    }

    public void exitPressed()
    {
        this.sceneSwitcher.switchToScene("Menu");
    }
}
