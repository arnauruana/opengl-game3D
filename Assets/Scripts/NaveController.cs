using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public Level1Controller level1Controller;

   
    public Transform lookBall;
    public Transform moveBall;
    public Transform player;

    public float movementSpeed = 45f;
    public float cameraSpeed = 45f;
    public float rotationSpeed = 45f;
    private float startDistance = 5f;

    //Funcion principal
    public void Move(float h, float v)
    {
        MoveXY(h, v);
        GotoMoveBall();
        RotatetoLookBall();
    }

    //Mueve el MoveTarget segun el input
    void MoveXY(float x, float y)
    {
        Vector3 dir = new Vector3(x, y, 0);
        Vector3 force = dir * movementSpeed;
        moveBall.localPosition += force * Time.deltaTime;

        //en pruebas
        Clamp();
    }

    //La nave no puede salir de la camara
    void Clamp()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.Clamp01(pos.x), Mathf.Clamp01(pos.y), pos.z));
    }

    //Mueve Player hacia el MoveTarget
    void GotoMoveBall()
    {
        Vector3 moveBallPos = moveBall.position;
        Vector3 playerPos = transform.position;

        transform.position = Vector3.MoveTowards(playerPos, moveBallPos, movementSpeed * Time.deltaTime); //multiplicar por velocidad

        //Recupera la distancia z entre la bola de movimiento y el player
        Vector3 localPlayerPos = transform.localPosition;
        localPlayerPos.z = startDistance;
        transform.localPosition = localPlayerPos;
    }

    //Hace que la nave apunte al AimTarget
    void RotatetoLookBall()
    {
        Quaternion rotation = Quaternion.LookRotation((lookBall.position - transform.position).normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
       // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookBall.position), Mathf.Deg2Rad * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            level1Controller.SetWin();
        }
    }

}