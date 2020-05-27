using UnityEngine;


public class EnemyShipMovement : MonoBehaviour
{
    public float speed;

    private float rotation;

    void Awake()
    {
        this.rotation = 0;
    }

    void FixedUpdate()
    {
        if (this.gameObject.tag == "EnemySpaceShip")
        {
            this.transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }

        else if (this.gameObject.tag == "EnemyTank")
        {
            this.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        
        else if (this.gameObject.tag == "EnemyDroid")
        {
            if (this.rotation == 360)
            {
                this.rotation = 0;
            }

            this.rotation += 150 * Time.deltaTime;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, this.rotation);
            this.gameObject.transform.Translate(0, speed * Time.deltaTime, -speed * Time.deltaTime);
        }
    }
}