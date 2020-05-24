using UnityEngine;


public class Trigger : MonoBehaviour
{
    public GameObject fireBallEnemy;
    public AudioSource shotSound;
    public Transform aimRotation;

    public float destroyDelay;
    public float fireRate;
    public float shotRange;

    private float timeToFire;

    void Start()
    {
        this.timeToFire = 0f;
    }

    public void shoot()
    {
        if (Time.time >= this.timeToFire)
        {
            this.timeToFire = Time.time + 1 / this.fireRate;
            this.shootFireball();
        }
    }

    private void shootFireball()
    {
        this.shotSound.Play();

        Transform onTopHierachy = this.transform.parent.parent.parent.parent.parent.parent;
        GameObject fireballEnemy = Instantiate(this.fireBallEnemy, this.aimRotation.position, this.aimRotation.rotation, onTopHierachy) as GameObject;
        Destroy(fireballEnemy, this.destroyDelay);
    }
}
