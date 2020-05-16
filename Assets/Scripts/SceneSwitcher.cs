using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    private static SceneSwitcher instance;

    public void switchToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Awake()
    {
        if (SceneSwitcher.instance != null)
        {
            SceneSwitcher.Destroy(this.gameObject);
        }
        else
        {
            SceneSwitcher.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.switchToScene(0);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            this.switchToScene(1);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            this.switchToScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            this.switchToScene(3);
        }
    }
}