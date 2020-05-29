using UnityEngine;


public class EndGame : MonoBehaviour
{
    private SceneSwitcher sceneSwitcher;

    private void Start()
    {
        this.sceneSwitcher = GameObject.FindObjectOfType<SceneSwitcher>();
    }

    public void continuePressed()
    {
        this.sceneSwitcher.switchToScene(0);
    }
}
