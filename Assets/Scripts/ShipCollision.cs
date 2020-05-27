using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{
    private Level1Controller[] level1Controller;
    private Level2Controller[] level2Controller;

    public HealthBar health;
    public GameObject explosionEffect;
       
    
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            level1Controller = FindObjectsOfType(typeof(Level1Controller)) as Level1Controller[];

         //   this.gameObject.GetComponent(typeof(Level1Controller)) as Level1Controller;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            level2Controller = FindObjectsOfType(typeof(Level2Controller)) as Level2Controller[];

            //level2Controller = this.gameObject.GetComponent(typeof(Level2Controller)) as Level2Controller;
        }
        //
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "AllyFireball")
        {
            this.explode();
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

    void OnTriggerEnter(Collider collider)
    {
        //tag cambiable para distinguir enemigos
        if (collider.tag == "EnemyFire")
        {
            this.health.Damage(20);
        }
        else
        {
            this.explode();
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
    
    public void explode()
    {
        GameObject explosion = Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation) as GameObject;

        Destroy(explosion, 8);
        Destroy(this.transform.parent.gameObject);
    }


    void OnParticleTrigger()
    {
        this.explode();
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
