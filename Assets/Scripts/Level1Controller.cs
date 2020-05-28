using System;

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
    public Trigger turretTrigger1;
    public Trigger turretTrigger2;
    public Trigger turretTrigger3;

    [Header("Torretas")]
    public Transform torreta1;
    public Transform torreta2;
    public Transform torreta3;

    [Header("Torretas")]
    public Transform tanque1;
    public Transform tanque2;
    public Transform tanque3;
    public Transform tanque1Canion;
    public Transform tanque2Canion;
    public Transform tanque3Canion;

    [Header("UI")]
    public GameObject healthBar;

    private bool win;
    private SceneSwitcher sceneSwitcher;

    void Awake()
    {
        this.sceneSwitcher = GameObject.FindObjectOfType<SceneSwitcher>();
    }

    void Start()
    {
        win = false;
    }

    void Update()
    {
        if (this.airTrackCart != null && this.airTrackCart.m_Position >= 1700f)
        {
            this.SetWin();
        }

        if (this.player == null) return;

        this.turretsAI();
        this.tanksAI();
    }

    private void turretsAI()
    {
        Quaternion rotation;
        Vector3 aim = this.player.position + new Vector3(0, 0, 10);

        if (this.torreta1 != null && dist(player.position, torreta1.position) < this.turretTrigger1.shotRange)
        {
            rotation = Quaternion.LookRotation((aim - torreta1.position).normalized);
            rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, torreta1.rotation.eulerAngles.z);
            torreta1.rotation = Quaternion.Lerp(torreta1.rotation, rotation, 30 * Time.deltaTime);
            this.turretTrigger1.shoot();
        }

        if (this.torreta2 != null && dist(player.position, torreta2.position) < this.turretTrigger2.shotRange)
        {
            rotation = Quaternion.LookRotation((aim - torreta2.position).normalized);
            rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, torreta2.rotation.eulerAngles.z);
            torreta2.rotation = Quaternion.Lerp(torreta2.rotation, rotation, 30 * Time.deltaTime);
            this.turretTrigger2.shoot();
        }

        if (this.torreta3 != null && dist(player.position, torreta3.position) < this.turretTrigger3.shotRange)
        {
            rotation = Quaternion.LookRotation((aim - torreta3.position).normalized);
            rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, torreta3.rotation.eulerAngles.z);
            torreta3.rotation = Quaternion.Lerp(torreta3.rotation, rotation, 30 * Time.deltaTime);
            this.turretTrigger3.shoot();
        }
    }

    private void tanksAI()
    {
        Quaternion rotation_head;
        Quaternion rotation_canion;


        rotation_head = Quaternion.LookRotation((this.player.position - tanque1.position).normalized, Vector3.up);
        rotation_head = Quaternion.Euler(tanque1.rotation.eulerAngles.x, rotation_head.eulerAngles.y, tanque1.rotation.eulerAngles.z); //cabeza solo en Y
        tanque1.rotation = Quaternion.Lerp(tanque1.rotation, rotation_head, 30 * Time.deltaTime);

        rotation_canion = Quaternion.LookRotation((this.player.position - tanque1Canion.position).normalized, Vector3.up);
        rotation_canion = Quaternion.Euler(tanque1Canion.rotation.eulerAngles.x, tanque1Canion.rotation.eulerAngles.y, rotation_canion.eulerAngles.z); //cañon solo en Z
        tanque1Canion.rotation = Quaternion.Lerp(tanque1Canion.rotation, rotation_canion, 30 * Time.deltaTime);
    }
    

    private float dist(Vector3 p, Vector3 q)
    {
        float x = q.x - p.x;
        float y = q.y - p.y;
        float z = q.z - p.z;

        x *= x;
        y *= y;
        z *= z;

        return (float)Math.Sqrt(x + y + z);
    }

    public void SetWin()
    {
        this.win = true;
        this.sceneSwitcher.switchToScene(2);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        this.airTrackCart.m_Speed = 0;
        this.playerController.enabled = false;

        //this.shipCollision.explode();

        this.healthBar.SetActive(false);
        this.gameOverMenu.SetActive(true);
    }
}
