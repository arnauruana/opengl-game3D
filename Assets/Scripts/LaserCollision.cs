using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public ShipCollision shipCollision;
    public Level1Controller level1Controller;

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "AllyShip")
        {
            shipCollision.explode();
            level1Controller.gameOver();
        }
    }
}
