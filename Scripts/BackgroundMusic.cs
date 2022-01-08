using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //private static variable of background music
    private static BackgroundMusic backgroundMusic;

    void Awakec()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

 /* Main Menu Music Credentials
   Summer Evening by Keys of Moon | https://soundcloud.com/keysofmoon
   Music promoted by https://www.chosic.com/free-music/all/
   Attribution 4.0 International (CC BY 4.0)
   https://creativecommons.org/licenses/by/4.0/ 
 */

}
