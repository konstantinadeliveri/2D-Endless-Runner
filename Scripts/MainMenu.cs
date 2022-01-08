using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject deathmenu;
    [SerializeField] public GameObject mainmenu;
    //say what scene we want the game to look so it can start
    public string playGameRunner;

    public GameObject Dmenu;
    public GameObject Mmenu;
   
    void Awake()
    {
        //if menu was loaded because player died, check in case multiple menus were loaded, and unload any excess ones
        //this was rough to fix, probably can be done better
        for(; Die.manymenu > 0; Die.manymenu--)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(1);
        }
        Dmenu = deathmenu;
        Mmenu = mainmenu;
        //if player died, change from main menu to death menu
        if (PlayerCharacterController.dead == true)
        {
            Mmenu.SetActive(false);
            Dmenu.SetActive(true);
        }

    }

    //open the endless runner scene to play
    public void PlayGame()
    {
        SceneManager.LoadScene(playGameRunner);
    }
    //open the store scene, adding event
    //open option scene of the game we don't need programming, just add an event of the OptionsMenu
    
    //quit game 
    public void ExitGame()
    {
        //Debug.Log("Quit"); /*only to check if exit button works in unity*/
        Application.Quit();
    }

}
