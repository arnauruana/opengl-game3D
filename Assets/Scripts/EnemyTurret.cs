using UnityEngine;


public class EnemyTurret : MonoBehaviour
{
    public GameObject explosionEffect;
    public int health;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "AllyFireball")
        {
            this.damage(50);
        }
    }

    public void damage(int damage)
    {
        this.health -= damage;

        if (this.health <= 0)
        {
            this.explode();
        }
    }

    public void explode()
    {
        GameObject explosion = Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(explosion, 5);

        Destroy(this.transform.parent.parent.gameObject);
    }
}
