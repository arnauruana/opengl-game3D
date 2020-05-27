using System;

using UnityEngine;


public class EnemyShipTrigger : MonoBehaviour
{
    [Header("Objects")]
    public GameObject enemyFireball;
    public AudioSource shotSound;
    public Transform playerShip;


    [Header("Options")]
    public float destroyDelay;
    public float fireRate;
    public float shotRange;

    private float timeToFire;

    void Start()
    {
        this.timeToFire = 0f;
    }

    void Update()
    {
        if (this.playerShip != null && dist(this.playerShip.position, this.transform.position) < this.shotRange)
        {
            this.transform.rotation = Quaternion.LookRotation((this.playerShip.position - this.transform.position).normalized);
            this.shoot();
        }
    }

    public void shoot()
    {
        if (Time.time >= this.timeToFire)
        {
            this.timeToFire = Time.time + 1 / this.fireRate;
            this.shootFireball();
        }
    }

    public void shootFireball()
    {   
        this.shotSound.Play();

        Transform onTopHierarchy = this.transform.parent.parent;
        GameObject enemyFireball = Instantiate(this.enemyFireball, this.transform.position, this.transform.rotation, onTopHierarchy) as GameObject;
        Destroy(enemyFireball, this.destroyDelay);
    }

    private float dist(Vector3 p, Vector3 q)
    {
        float x = q.x - p.x;
        float y = q.y - p.y;
        float z = q.z - p.z;

        x *= x;
        y *= y;
        z *= z;

        return (float)Math.Sqrt(x + y + z);
    }
}
