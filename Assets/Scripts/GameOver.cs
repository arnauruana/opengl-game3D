using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    private SceneSwitcher sceneSwitcher;

    void Awake()
    {
        this.sceneSwitcher = GameObject.FindObjectOfType<SceneSwitcher>();
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