using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Te asegura que se realiza despues de todos los updates,
    // asi nos aseguramos de que el player ya se haya movido
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        
    }
}
