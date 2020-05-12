using UnityEngine;


public class Disparador : MonoBehaviour
{
    public GameObject fireballprefab;

    public void CreateFireball()
    {
        Transform topHierachy = transform.parent.parent.parent.parent.parent.parent;

        Instantiate(fireballprefab, transform.position, transform.rotation, topHierachy);
    }
}