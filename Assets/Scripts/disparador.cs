using UnityEngine;


public class Disparador : MonoBehaviour
{
    public Camera camera;
    public GameObject fireball;

    public float destroyDelay;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            this.shootFireball();
        }
    }

    public void shootFireball()
    {
        Transform onTopHierachy = transform.parent.parent.parent.parent.parent.parent;

        GameObject fireball = Instantiate(this.fireball, transform.position, transform.rotation, onTopHierachy) as GameObject;
        Destroy(fireball, this.destroyDelay);
    }
}