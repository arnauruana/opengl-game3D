using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public Level1Controller level1Controller;
    public HealthBar health;
    public GameObject explosionEffect;
       
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "AllyFireball")
        {
            this.explode();
            this.level1Controller.gameOver();
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
            this.level1Controller.gameOver();
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
        this.level1Controller.gameOver();
    }
}
