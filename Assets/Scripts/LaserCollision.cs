using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public HealthBar heatlh;
    public ShipCollision shipCollision;

    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "AllyShip")
        {
            this.heatlh.Damage(100);   
        }
    }
}
