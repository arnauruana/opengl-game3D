using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    private static SceneSwitcher instance;

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void switchToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void switchToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Awake()
    {
        if (SceneSwitcher.instance == null)
        {
            SceneSwitcher.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            SceneSwitcher.Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            this.switchToScene(1);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            this.switchToScene(2);
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            this.switchToScene(0);
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            this.switchToScene(3);
        }
    }
}