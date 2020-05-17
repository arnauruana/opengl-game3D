using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Manager")]
    public Level1Controller level1Controller;

    [Header("Controller")]
    public NaveController naveController;
    public Disparador disparador;
    public Transform nave;

    private Vector3 posIni;
    private float h, v;

    [Header("Variables de juego")]
    [Header("Vida")]
    public int maxLife=100;
    public int currentLife = 0;
    public HealthBar healthbar;

    void Start()
    {
        posIni = nave.transform.position;
        currentLife = maxLife;
        healthbar.SetMaxHealth(maxLife);
        healthbar.SetHealth(currentLife);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // *******Mover con el teclado *******
         h = Input.GetAxis("Horizontal");
         v = Input.GetAxis("Vertical");

        // *******Mover con el ratón *******
        // h = Input.GetAxis("Mouse X");
        // v = Input.GetAxis("Mouse Y");
        naveController.Move(h, v);
    } 
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            // Debug.Log("PIUN!");
            //disparador.CreateFireball();
            // Damage(10);
           
           naveController.DoRoll();
           
        }
    }

    public void Damage(int damage)
    {
        currentLife -= damage;

        healthbar.SetHealth(currentLife);

        if (this.currentLife <= 0)
        {
            Debug.Log("DEAD");

            this.level1Controller.gameOver();
        }
    }
}