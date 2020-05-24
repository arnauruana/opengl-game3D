using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    public Level1Controller level1Controller;
    public PlayerController player;
    public HealthBar health;

    public Cinemachine.CinemachineDollyCart cart;

    public GameObject explosionEffect;

    public float restartDelay;
       

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "AllyFireball")
        {
            if (collision.collider.tag == "EnemyFire") // impacto con misil enemigo
            {
                this.health.Damage(20);
            }
            else // choque contra obstaculo
            {
                this.explode();
                this.level1Controller.gameOver();
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
