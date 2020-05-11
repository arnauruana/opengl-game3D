using UnityEngine;

public class disparador : MonoBehaviour
{
    public GameObject fireballprefab;

    public void CreateFireball()
    {
        Transform topHierachy = transform.parent.parent.parent.parent.parent.parent;

        Instantiate(fireballprefab, this.transform.position, this.transform.rotation, topHierachy);
    }
}