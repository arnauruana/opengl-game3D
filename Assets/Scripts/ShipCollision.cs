using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{

    public HealthBar health;
    public GameObject explosionEffect;
    public Rigidbody rigidbody;
       
    private GodMode godMode;

    void Awake()
    {
        this.godMode = GameObject.FindObjectOfType<GodMode>();
    }

    void Update()
    {
        this.rigidbody.isKinematic = this.godMode.isEnabled();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Terrain") this.health.Damage(100);
    }

    void OnTriggerEnter(Collider collider)
    {
        //tag cambiable para distinguir enemigos
        if (collider.tag == "EnemyFire") this.health.Damage(20);
        else if (collider.tag == "Terrain") this.health.Damage(100);
        else this.health.Damage(100);
    }
    
    public void explode()
    {
        GameObject explosion = Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation) as GameObject;

        Destroy(explosion, 8);
        Destroy(this.transform.parent.gameObject);
    }


    void OnParticleTrigger()
    {
        this.health.Damage(100);
    }
}
