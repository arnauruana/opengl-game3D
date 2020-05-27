﻿using UnityEngine;


public class EnemyShipMovement : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        if (this.gameObject.tag == "EnemySpaceShip")
        {
            this.transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }

        else if (this.gameObject.tag == "EnemyTank")
        {
            this.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}