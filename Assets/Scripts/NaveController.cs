using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public Level1Controller level1Controller;

    [Header("Targets")]
    public Transform aimTarget;
    public Transform moveTarget;
    public Transform player;

    [Header("Speeds")]
    public float movementSpeed =45f;
    public float cameraSpeed = 45f;
    public float rotationSpeed = 45f;

    public Camera camera;
    private float startDistance = 5f;

    void Start()
    {
        camera = GetComponentInParent<Camera>();
        startDistance = Vector3.Distance(camera.transform.position, transform.position);
    }

    //Funcion principal
    public void Move(float h, float v)
    {
        MoveXY(h, v);
        //MoveZ no es necesario con el dollycart
       // MoveZ();
        MovePlayerToMoveTarget();
        RotatePlayerToAimTarget();
    }

    //Mueve el MoveTarget segun el input
    void MoveXY(float h, float v)
    {
        Vector3 dir = new Vector3(h, v, 0);
        Vector3 force = dir * movementSpeed;
        moveTarget.localPosition += force * Time.deltaTime;
        //en pruebas
        Clamp();
    }

    //La nave no puede salir de la camara
    void Clamp()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.Clamp01(pos.x), Mathf.Clamp01(pos.y), pos.z));
    }

    //Hace que avance en el eje z
    void MoveZ()
    {
       // camera.transform.position += camera.transform.forward * cameraSpeed * Time.deltaTime;
        player.position += player.forward * cameraSpeed * Time.deltaTime;
    }

    //Mueve Player hacia el MoveTarget
    void MovePlayerToMoveTarget()
    {
        Vector3 moveTargetPos = moveTarget.position;
        Vector3 playerPos = transform.position;

        transform.position = Vector3.MoveTowards(playerPos, moveTargetPos, movementSpeed * Time.deltaTime); //multiplicar por velocidad

        //Recupera la distancia z entre el MoveTarget y el player
        Vector3 localPlayerPos = transform.localPosition;
        localPlayerPos.z = startDistance;
        transform.localPosition = localPlayerPos;
    }

    //Hace que la nave apunte al AimTarget
    void RotatePlayerToAimTarget()
    {
        Quaternion rotation = Quaternion.LookRotation((aimTarget.position - transform.position).normalized);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
       // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * rotationSpeed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Win")
        {
            level1Controller.SetWin();
        }
    }

}