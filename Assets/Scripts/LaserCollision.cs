using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    private Level1Controller[] level1Controller;
    private Level2Controller[] level2Controller;

    public ShipCollision shipCollision;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            level1Controller = FindObjectsOfType(typeof(Level1Controller)) as Level1Controller[];

            //   this.gameObject.GetComponent(typeof(Level1Controller)) as Level1Controller;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            level2Controller = FindObjectsOfType(typeof(Level2Controller)) as Level2Controller[];

            //level2Controller = this.gameObject.GetComponent(typeof(Level2Controller)) as Level2Controller;
        }
    }
    void OnParticleCollision(GameObject obj)
    {
        if (obj.tag == "AllyShip")
        {
            shipCollision.explode();
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                this.level1Controller[0].gameOver();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                this.level2Controller[0].gameOver();
            }
        }
    }
}
