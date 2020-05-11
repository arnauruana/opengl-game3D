using UnityEngine;
using UnityEngine.SceneManagement;


public class Level1Controller : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Torretas")]
    public Transform torreta1;
    public Transform torreta2;
    public Transform torreta3;

    private bool win;

    void Start()
    {
        win = false;
    }
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation((player.position - torreta1.position).normalized);
        torreta1.rotation = Quaternion.Lerp(torreta1.rotation, rotation, 20 * Time.deltaTime);
        rotation = Quaternion.LookRotation((player.position - torreta2.position).normalized);
        torreta2.rotation = Quaternion.Lerp(torreta2.rotation, rotation, 20 * Time.deltaTime);
        rotation = Quaternion.LookRotation((player.position - torreta3.position).normalized);
        torreta3.rotation = Quaternion.Lerp(torreta3.rotation, rotation, 20 * Time.deltaTime);
    }

    public void SetWin()
    {
        win = true;
        Debug.Log("Win!");
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
