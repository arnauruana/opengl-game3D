using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class ShowValue : MonoBehaviour
{
    public TextMeshProUGUI onoffText;
    public TextMeshProUGUI percentageText;
    
    public Toggle myToggle;

    public void textUpdateVolume(float value)
    {
        this.percentageText.text = Mathf.RoundToInt(value * 100) + "%";
    }

    public void textUpdateGodMode()
    {
        if (this.myToggle.isOn) this.onoffText.text = "On";
        else this.onoffText.text = "Off";
    }
}