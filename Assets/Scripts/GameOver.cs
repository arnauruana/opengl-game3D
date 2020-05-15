using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void restartPressed()
    {
        SceneManager.LoadScene("Level1");
        // SceneManager.LoadScene("Level2");
    }

    public void exitPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}