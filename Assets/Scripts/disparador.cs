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
            Ray target = this.camera.ScreenPointToRay(Input.mousePosition);
            this.transform.rotation = Quaternion.Euler(target.direction);
            this.shootFireball();
        }
    }

    public void shootFireball()
    {
        Transform onTopHierachy = this.transform.parent.parent.parent.parent.parent.parent;

        GameObject fireball = Instantiate(this.fireball, this.transform.position, this.transform.rotation, onTopHierachy) as GameObject;
        Destroy(fireball, this.destroyDelay);
    }
}