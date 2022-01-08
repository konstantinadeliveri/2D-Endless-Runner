using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallConrol2 : MonoBehaviour
{
    //ignore comented code, is/was for testing purposes


    // GameObject PC = GameObject.Find("Player");
    // PlayerCharacterController PCscript = PC.GetComponent<PlayerCharacterController>();

    //variable for the death effect sound
    AudioSource DeadSound;
    // Start is called before the first frame update
    void Start()
    {
        //get refference for audiosource component of this object
        DeadSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if ((this.GetComponent<Rigidbody>() != null) && this.GetComponent<Rigidbody>().IsSleeping())
        //{
        //    this.GetComponent<Rigidbody>().WakeUp();
        //}
    }
    //when collision between this object(floating spiked ball) and other object(player) happens,if player isnt sliding, delete player ,set him as dead and start the process of loading death menu
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.Find("MC").GetComponent<PlayerCharacterController>().isSliding == false)
        {
            DeadSound.Play();
            StartCoroutine(LoadYourAsyncScene());
            PlayerCharacterController.dead = true;
            other.gameObject.SetActive(false);
        }

    }
    //process for loading death menu. necessary to make sure the death menu is loaded instead of the main menu // PARTIALLY NOT OURS, TAKEN FROM INTERNET. SOME LINES NEEDED TO BE CHANGED
    IEnumerator LoadYourAsyncScene()
    {
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
        //necessary variable we added to avoid loading multiple menus. if not included, on death the loading of menus triggers more than once depending on framerate (based on testing, usually twice depending on death trigger)
        Die.manymenu++;
    }
}
