using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public string Game;

    //create restart script in the main game when restart button pressed load game
    public void RestartGame()
    {
        SceneManager.LoadScene(Game);
    }

    // button for store menu was handled with unity...when store button pressed disable death menu and enable store menu

    // quit to main menu loads main menu level
    public void QuitToMainMenu()
    {
        Application.LoadLevel(mainMenuLevel);
    }


}
