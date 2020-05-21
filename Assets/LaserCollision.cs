using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public ShipCollision shipCollision;
    public Level1Controller level1Controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision()
    {
        shipCollision.explode();
        level1Controller.gameOver();
    }
}
