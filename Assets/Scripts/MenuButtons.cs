using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject credits;
    public GameObject options;
    public GameObject controls;
    public GameObject surequit;

    public Button play;
    public Button opts;
    public Button conts;
    public Button creds;
    public Button quit;

    public Button no;
    public Button yes;
    public Button back;
    public Button back2;
    public Button back3;

    public FadeTransition fadeTransition; 

    private enum Selection
    {
        play,
        options,
        controls,
        credits,
        quit
    };
    private Selection selectedButton;

    void Start()
    {
        this.play.Select();

        this.selectedButton = Selection.play;
    }

    public void PlayGame()
    {
        fadeTransition.Fade();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void goCredits()
    {
        this.selectedButton = Selection.credits;

        this.credits.SetActive(true);
        this.gameObject.SetActive(false);
        
        this.back.Select();
    }
    
    public void goSureQuit()
    {
        this.selectedButton = Selection.quit;

        this.surequit.SetActive(true);
        this.gameObject.SetActive(false);

        this.no.Select();
    }

    public void goControls()
    {
        this.selectedButton = Selection.controls;

        this.controls.SetActive(true);
        this.gameObject.SetActive(false);

        this.back3.Select();
    }

    public void goOptions()
    {
        this.selectedButton = Selection.options;

        this.options.SetActive(true);
        this.mainmenu.SetActive(false);

        this.back2.Select();
    }

    public void goMenu()
    {
        this.options.SetActive(false);
        this.controls.SetActive(false);
        this.credits.SetActive(false);
		this.surequit.SetActive(false);
        this.mainmenu.SetActive(true);

		this.recoverSelection();
    }

    private void recoverSelection()
    {
        switch (selectedButton)
        {
        	case Selection.play:
            {
                this.play.Select();
                break;
            }
            case Selection.options:
            {
                this.opts.Select();
                break;
            }
            case Selection.controls:
            {
                this.conts.Select();
                break;
            }
            case Selection.credits:
            {
                this.creds.Select();
                break;
            }
			case Selection.quit:
			{
				this.quit.Select();
				break;
			}
            default:
            {
				this.play.Select();
                break;
            }
        }
    }
}