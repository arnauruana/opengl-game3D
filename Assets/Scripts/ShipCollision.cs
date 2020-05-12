using UnityEngine;


public class ShipCollision : MonoBehaviour
{
    public Level1Controller controller;

    public Cinemachine.CinemachineDollyCart cart;

    // public GameObject explosionEffect; // link with the BigExplosion prefab from Unity Particle Pack 

    public float restartDelay;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "AllyFireball")
        {
            this.cart.m_Speed = 5f; // slows down the cart of the airtack

            this.explode();

            this.controller.Invoke("restartScene", this.restartDelay); // restart the secene
        }
    }

    void explode()
    {
        // Instantiate(this.explosionEffect, this.transform.position, this.transform.rotation);
        Debug.Log("BOOM");
        Destroy(this.gameObject);
    }
}
