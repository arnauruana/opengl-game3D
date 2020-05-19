using UnityEngine;


public class Disparador : MonoBehaviour
{
    public GameObject fireball;

    public float destroyDelay;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = Input.mousePosition;
            Debug.Log(target);
            this.transform.LookAt(target);
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