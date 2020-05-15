using UnityEngine;


public class ShipCollision : MonoBehaviour
{
    public Level1Controller level1Controller;
    public PlayerController player;

    public Cinemachine.CinemachineDollyCart cart;

    public GameObject explosionEffect;

    public float restartDelay;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "AllyFireball")
        {
            this.explode();

            this.level1Controller.gameOver();
        }
    }

    public void explode()
    {
        Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation);

        Destroy(this.explosionEffect);
        Destroy(this.gameObject);
    }
}
