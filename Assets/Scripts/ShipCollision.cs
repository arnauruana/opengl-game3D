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
            if (collision.collider.tag == "EnemyFire")
            {
                this.health.Damage(20);
            }
            else
            {
                this.explode();
                this.level1Controller.gameOver();
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
        this.level1Controller.gameOver();
    }
}
