using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class ShowValue : MonoBehaviour
{
    public TextMeshProUGUI percentageText;
    public MusicController musicController;

    

    
    void Update()
    {
        
    }
    public void textUpdateVolume(float value)
    {
        musicController.lastVolume = value;
        this.percentageText.text = value + "%";
        musicController.changeVolume();
        
    }

    
}