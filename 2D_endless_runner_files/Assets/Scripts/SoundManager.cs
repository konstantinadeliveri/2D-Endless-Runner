using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image SoundOn;
    [SerializeField] Image SoundOff;
    public static bool muted = false; // when start set muted to false

    void Start()
    {
        
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon(); //call update button icon function
        AudioListener.pause = muted; //set it to muted
    }


    // that's how we set the sound icon to change whenever we click on the sound icon (from on to off and off to on)
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save(); //must call save function to see if true or false
        UpdateButtonIcon(); //call update button icon function
    }

    // show it with the sound icons 
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
        }
        else
        {
            SoundOn.enabled = false;
            SoundOff.enabled = true;
        }

    }


    private void Load()
    {
        //here we check if the converted boolean value equals to 1(true) so that main menu music is playing when in main menu
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        // set a boolean value as integer, whenever 1(true) or 0(false)
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
