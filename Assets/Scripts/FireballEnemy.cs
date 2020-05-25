using UnityEngine;


public class FireballEnemy : MonoBehaviour
{
    [Header("Effects")]
    public GameObject explosion;

    [Header("Options")]
    public float speed;

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

        Destroy(this.gameObject);
    }
}
