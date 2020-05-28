using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioSource transition;
    public AudioSource menuMusic;
    public bool mute;
    public float lastVolume;
    public float volume;
    public ShowValue showValue;
    // Start is called before the first frame update
    void Start()
    {
        mute = false;
        volume = lastVolume =  100;
        showValue.textUpdateVolume(volume);

    }
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mute = !mute;
            changeVolume();
        }
    }

    public void changeVolume(){
        if (!mute)
        {
            volume = lastVolume;
            AudioListener.volume = lastVolume;
        }
        else
        {
            volume = 0f;
            AudioListener.volume = 0f;
        }
        //PlayerPrefs.SetFloat("volume", 0.0F);
        /*transition.volume = 0.06f * (volume / 100);
        menuMusic.volume = 0.15f * (volume / 100);
        AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int index = 0; index < sources.Length; ++index)
        {
            if (mute) sources[index].volume = 0f;
            else sources[index].volume = lastVolume/100;
        }
     */   
    }
}
