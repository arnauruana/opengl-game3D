using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class ShowValue : MonoBehaviour
{
    public TextMeshProUGUI percentageText;
    

    public AudioSource transition;
    public AudioSource menuMusic;
    public bool mute;
    public float volume;

    void Start()
    {
        mute = false;
        volume = 100;
        textUpdateVolume(volume);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) )
        {
            if (mute)
            {
                mute = false;
                textUpdateVolume(volume);

            }
            else
            {
                mute = true;
                textUpdateVolume(0);
            }

        }
    }
    public void textUpdateVolume(float value)
    {
        if (!mute) volume = value;
        this.percentageText.text = value + "%";
        transition.volume = 0.06f * (value/100);
        menuMusic.volume = 0.15f * (value/100);
    }

    
}