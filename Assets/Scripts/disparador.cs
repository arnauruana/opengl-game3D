using UnityEngine;


public class Disparador : MonoBehaviour
{
    public Camera camera;
    public GameObject fireball;
    public AudioSource shotSound;

    public float maximumLength;
    public float destroyDelay;
    public float fireRate;
    
    private Ray rayMouse;
    private Vector3 position;
    private Vector3 direction;
    private Quaternion rotation;

    private Quaternion finalrotation;
    private GameObject aux;
    private float timeToFire;

    void Start()
    {
        this.timeToFire = 0f;
    }
    /*ORIGINAL
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= this.timeToFire)
        {
            this.timeToFire = Time.time + 1 / this.fireRate;

            this.rayMouse = this.camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(this.rayMouse.origin, this.rayMouse.direction, out hit, this.maximumLength))
            {
                this.rotateToMouseDirection(this.gameObject, hit.point);
            }
            else
            {
                this.position = this.rayMouse.GetPoint(this.maximumLength);
                this.rotateToMouseDirection(this.gameObject, this.position);
            }

            this.shootFireball();
        }
    }
    
    private void rotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        this.direction = destination - obj.transform.position;
        this.rotation = Quaternion.LookRotation(this.direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
    
    private void shootFireball()
    {
        this.shotSound.Play();

        Transform onTopHierachy = this.transform.parent.parent;
        GameObject fireball = Instantiate(this.fireball, this.transform.position, this.transform.rotation, onTopHierachy) as GameObject;
        Destroy(fireball, this.destroyDelay);
    }*/

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= this.timeToFire)
        {
            this.timeToFire = Time.time + 1 / this.fireRate;

            this.rayMouse = this.camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(this.rayMouse.origin, this.rayMouse.direction, out hit, this.maximumLength))
            {
                this.rotateToMouseDirection(this.gameObject, hit.point);
            }
            else
            {
                this.position = this.rayMouse.GetPoint(this.maximumLength);
                this.rotateToMouseDirection(this.gameObject, this.position);
            }
            this.shootFireball();

        }
    }
    
    private void rotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        this.direction = destination - obj.transform.position;
        this.rotation = Quaternion.LookRotation(this.direction);
        finalrotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
    
    private void shootFireball()
    {
        this.shotSound.Play();

        Transform onTopHierachy = this.transform.parent.parent;
        GameObject fireball = Instantiate(this.fireball, this.transform.position, finalrotation, onTopHierachy) as GameObject;
        Destroy(fireball, this.destroyDelay);
    }
}