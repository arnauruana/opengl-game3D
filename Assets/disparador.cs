using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparador : MonoBehaviour
{

    public GameObject fireballprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFireball()
    {
        Instantiate(fireballprefab, transform);
    }
}
