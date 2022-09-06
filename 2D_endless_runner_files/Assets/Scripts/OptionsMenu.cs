using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //use the audio system for audio mixer to work
using UnityEngine.UI; //cause we want to change the light

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer musicMixer; //reference to music mixer
    public AudioMixer soundMixer; //reference to sound mixer

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("volume", volume); //set value volume(whatever the value of slider is)
    }

    //same for sound effects
    public void SetSoundEffectsVolume(float sound)
    {
        soundMixer.SetFloat("sound", sound); //set value sound(whatever the value of slider is)
    }
    //set quality options
    public void SetQuality(int qualityInt)
    {
        QualitySettings.SetQualityLevel(qualityInt);
    }
    //brightness options
    public Slider Brightness;
    public Light sceneLight;
    public void SetBrightness(float brightness)
    {
        sceneLight.intensity = Brightness.value; // gets the brightness value 
    }
}
