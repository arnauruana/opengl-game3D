using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller")]
    public NaveController naveController;
    public Disparador disparador;
    public Transform nave;

    private Vector3 posIni;
    private float h, v;

    [Header("Variables de juego")]
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
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //float h = Input.GetAxis("Mouse X");
        //float v = Input.GetAxis("Mouse Y");
        naveController.Move(h, v);
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("PIUN!");
            disparador.CreateFireball();
            Damage(10);
        }
    }

    public void Damage(int damage)
    {
        currentLife -= damage;

        healthbar.SetHealth(currentLife);

        if (this.currentLife <= 0)
        {
            Debug.Log("DEAD");
        }
    }
}