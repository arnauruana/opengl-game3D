using UnityEngine;


public class ShipCollision : MonoBehaviour
{
    public Level1Controller controller;

    public Cinemachine.CinemachineDollyCart cart;

    public float restartDelay;

    void OnCollisionEnter()
    {
        this.cart.m_Speed = 5f; // slows down the cart of the airtack
        this.controller.Invoke("restartScene", restartDelay); // restart the secene
    }
}
