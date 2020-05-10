using UnityEngine;


public class InitMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject credits;
    public GameObject options;
    public GameObject controls;
    public GameObject surequit;

    void Start()
    {
        this.credits.SetActive(false);
        this.options.SetActive(false);
        this.controls.SetActive(false);
        this.surequit.SetActive(false);
        this.mainmenu.SetActive(true);
    }
}