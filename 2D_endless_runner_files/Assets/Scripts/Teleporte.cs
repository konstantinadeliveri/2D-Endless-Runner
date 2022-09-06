using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    //Set exit point portal for this pair
    public Transform Exit;
    //refference character object
    public GameObject MainChar;
    //variable for the teleport effect sound
    AudioSource TeleSound;
    // Start is called before the first frame update
    void Start()
    {
        //set player's character as the refference
        MainChar = GameObject.FindGameObjectWithTag("Player");
        //get refference for audiosource component of this portal
        TeleSound = GetComponent<AudioSource>();
    }
        
    

    // Update is called once per frame
    void Update()
    {
        
    }

    //when player char collides with this portal, move them instantly to the paired one
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TeleSound.Play();
            other.transform.position = Exit.transform.position;
        }

    }
}