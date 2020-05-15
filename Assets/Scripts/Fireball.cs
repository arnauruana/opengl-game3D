using UnityEngine;


public class Fireball : MonoBehaviour
{
    [Header("Effects")]
    public GameObject explosion;
    public GameObject fire;

    [Header("Options")]
    public float speed;
    public float destroyDelay;

    private Collision collision;

    void Start()
    {
        this.transform.Rotate(0, 180, 0);
        this.destroyFireball(false);
    }

    void FixedUpdate()
    {
        this.transform.Translate(speed * Vector3.right * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        this.collision = collision;

        this.destroyFireball(true);
    }

    public void destroyFireball(bool now)
    {
        if (now) // we have collided
        {
            Instantiate(this.explosion, this.transform.position, this.transform.rotation);
            
            if (this.collision.collider.tag == "Terrain") // fire on grass
            {
                Instantiate(this.fire, this.transform.position, this.transform.rotation);
                Destroy(this.fire);
            }

            Destroy(this.explosion);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, destroyDelay);
        }
    }
}
