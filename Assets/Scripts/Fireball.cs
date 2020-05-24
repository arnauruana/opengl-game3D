using UnityEngine;


public class Fireball : MonoBehaviour
{
    [Header("Effects")]
    public GameObject explosion;
    public GameObject fire;

    [Header("Options")]
    public float speed;
    public float flamesDuration;

    private Collider collider;

    void FixedUpdate()
    {
        this.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider collider)
    {

        this.collider = collider;
        this.destroyFireball();
    }


    public void destroyFireball()
    {
        GameObject explosion = Instantiate(this.explosion, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(explosion, 1);
        
        if (this.collider.tag == "Terrain") // fire on grass
        {
            GameObject fire = Instantiate(this.fire, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(fire, this.flamesDuration);
        }

        Destroy(this.gameObject);
    }
}
