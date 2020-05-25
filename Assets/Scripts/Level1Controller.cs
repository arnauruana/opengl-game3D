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

    [Header("UI")]
    public GameObject healthBar;

    private bool win;


    void Start()
    {
        win = false;
    }

    void Update()
    {
        Quaternion rotation;

        if (this.player == null) return;

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

        //this.shipCollision.explode();

        this.healthBar.SetActive(false);
        this.gameOverMenu.SetActive(true);
    }
}
