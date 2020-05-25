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
        Destroy(explosion, 1.75f);
        /*  Para el bucle de la animación de la explosion
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.loop = false;
        */
        //escala el tamaño de la explosion
        explosion.transform.localScale = new Vector3(2f, 2f, 2f);

        Destroy(this.transform.parent.parent.gameObject);
    }
}
