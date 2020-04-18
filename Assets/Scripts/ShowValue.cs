using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowValue : MonoBehaviour
{
    public TextMeshProUGUI percentageText;
    public TextMeshProUGUI onoffText;
    public Toggle myToggle;
    // Start is called before the first frame update
    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textUpdateVolume (float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 100) + "%";
    }
    public void textUpdateGodMode()
    {
        if (myToggle.isOn) onoffText.text = "On";
        else onoffText.text = "Off";
    }
}
