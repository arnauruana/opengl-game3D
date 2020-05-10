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
        percentageText.text = Mathf.RoundToInt(value * 100) + "%";
    }

    public void textUpdateGodMode()
    {
        if (myToggle.isOn) onoffText.text = "On";
        else onoffText.text = "Off";
    }
}