using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{

    //variable for the death effect sound
    AudioSource DeadSound;
    //bool to check if player has hit something deadly so the death code segment plays only once
    bool Colliding = false;
    //int to know how many menus have been loaded. used to unload multiples
    public static int manymenu = 0;
    // Start is called before the first frame update
    void Start()
    {
        //get refference for audiosource component of this object
        DeadSound = GetComponent<AudioSource>();
    }
    
    //method to asynchronously load the death menu. needed because simply loading the menu leaves the player at the *main* menu instead of the *death* one | NOT OUR CODE
    IEnumerator LoadYourAsyncScene()
    {
        if (!Colliding)
        {
            Colliding = true;

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(0);
            while (!asyncUnload.isDone)
            {
                yield return null;
            }
            //only line we added, to know how many times the menu has been loaded
            manymenu++;
        }  
    }


    //generic trigger for any object this script may be put on (ex. death balls or pit triggers). multiple redundant checks/ifs that attempt to solve the loading of multiple menus. menymenus variable does all the work in the end
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Colliding == false)
        {
            if (Colliding) return;
            //TextController.instance.AddGems();
            //this.gameObject.SetActive(false);
            if (!Colliding)
            {
                DeadSound.Play();
                StartCoroutine(LoadYourAsyncScene());
                Colliding = true;
            }
            PlayerCharacterController.dead = true;
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.SetActive(false);
            }
        }

    }

    //just in case something goes wrong and the player shoudln't have died
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Colliding == true)
        {
            Colliding = false;
        }
    }
    //just making sure the player doesn't randomly die
    void Update()
    {
        Colliding = false;
    }

}