using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Button restart;
    public Button exit;

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
