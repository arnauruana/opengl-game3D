﻿using UnityEngine;


public class InitMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject credits;
    public GameObject options;
    public GameObject controls;
    public GameObject surequit;

    void Start()
    {
        credits.SetActive(false);
        options.SetActive(false);
        controls.SetActive(false);
        surequit.SetActive(false);
        mainmenu.SetActive(true);
    }
}