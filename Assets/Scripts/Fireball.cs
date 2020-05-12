using UnityEngine;


public class Fireball : MonoBehaviour
{
    public float speed;
    public float destroyDelay;

    void Start()
    {
        this.transform.Rotate(0, 180, 0);
        this.destroyFireball();
    }

    void FixedUpdate()
    {
        this.transform.Translate(speed * Vector3.right * Time.deltaTime);
    }

    public void destroyFireball()
    {
        Destroy(this.gameObject, destroyDelay);
    }
}
