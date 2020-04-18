using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    public Button play;
    public GameObject mainmenu;
    public GameObject credits;
    public GameObject options;
    public GameObject controls;
    public GameObject surequit;
    public Button no;
    public Button yes;
    public Button back;
    public Button back2;
    void Start()
    {
        play.Select();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
       
        Application.Quit();
        Debug.Log("Quit");
    }

    public void goCredits()
    {
        credits.SetActive(true);
        back.Select();
        gameObject.SetActive(false);
    }
    
    public void goSureQuit()
    {
        surequit.SetActive(true);
        gameObject.SetActive(false);
        no.Select();
    }
    public void cancelquit()
    {
        surequit.SetActive(false);
        gameObject.SetActive(true);
        play.Select();
    }

    public void goControls()
    {
        controls.SetActive(true);
        gameObject.SetActive(false);
    }

    public void goOptions()
    {
        options.SetActive(true);
        mainmenu.SetActive(false);
        back2.Select();
    }

    public void goMenu()
    {
        controls.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
        mainmenu.SetActive(true);
        play.Select();

    }

}
