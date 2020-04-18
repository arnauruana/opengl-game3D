using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public NaveController naveController;
    public Transform nave;

    private Vector3 posIni;
    private float h, v;
    void Start()
    {
        posIni = nave.transform.position;
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

}