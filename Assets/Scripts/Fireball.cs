using UnityEngine;


public class Fireball : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float speed;

    private float forceX;
    private float forceY;
    private float forceZ;

    void Start()
    {
        this.forceX = 0f;
        this.forceY = 0f;
        this.forceZ = speed;
    }

    void FixedUpdate()
    {
        float x = this.forceX * Time.deltaTime;
        float y = this.forceY * Time.deltaTime;
        float z = this.forceZ * Time.deltaTime;

        this.rigidBody.AddForce(x, y, z);
    }
}
