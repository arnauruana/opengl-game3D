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
            else // choque contra nuestra nave (ya explota nuestra nave, no hace falta)
            {
                this.destroy();
            }
        }
    }

    public void explode()
    {
        GameObject explosion = Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation) as GameObject;
        explosion.transform.localScale = new Vector3(10f, 10f, 10f);
        Destroy(explosion, 2);
        /*  Para el bucle de la animación de la explosion
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.loop = false;
        */
        //escala el tamaño de la explosion
        Destroy(this.gameObject);
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
