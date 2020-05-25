using UnityEngine;

public class EnemyShipCollision : MonoBehaviour
{
    public Level1Controller level1Controller;
    public GameObject explosionEffect;
       

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "EnemyFire")
        {
            if (collider.tag == "AllyFireball") // destruccion contra nuestros disparos
            {
                this.explode();
            }
            else // choque contra nuestra nave
            {
                this.destroy();
            }
        }
    }

    public void explode()
    {
        GameObject explosion = Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation) as GameObject;
        explosion.transform.localScale = new Vector3(10f, 10f, 10f);
        Destroy(explosion, 8);
        Destroy(this.transform.parent.gameObject);
    }

    public void destroy()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
