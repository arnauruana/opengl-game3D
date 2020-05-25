using UnityEngine;


public class EnemyShipMovement : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.up * (speed * Time.deltaTime));
    }
}