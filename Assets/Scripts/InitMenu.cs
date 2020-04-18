using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitMenu : MonoBehaviour
{
    public Button play;
    public GameObject mainmenu;
    public GameObject credits;
    public GameObject options;
    public GameObject controls;
    public GameObject surequit;
    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        surequit.SetActive(false);
        mainmenu.SetActive(true);
       
        //play.Select();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    
}
