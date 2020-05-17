using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level1Controller : MonoBehaviour
{
    [Header("Menus")]
    public GameObject gameOverMenu;

    [Header("Player")]
    public Transform player;

    [Header("Scripts")]
    public PlayerController playerController;
    public Cinemachine.CinemachineDollyCart airTrackCart;
    public ShipCollision shipCollision;
    public Pause pauseMenu;

    [Header("Torretas")]
    public Transform torreta1;
    public Transform torreta2;
    public Transform torreta3;

    [Header("UI")]
    public GameObject healthBar;

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

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.pauseMenu.toggle();
        }
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

    public void gameOver()
    {
        this.airTrackCart.m_Speed = 0;
        this.playerController.enabled = false;

        this.shipCollision.explode();

        this.healthBar.SetActive(false);
        this.gameOverMenu.SetActive(true);
    }
}
