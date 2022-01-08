using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDie : MonoBehaviour
{
    //this script is to be used in death scenarios in the tutorial

    //works similarly to portals, find last checkpoint, get player character's object
    public Transform CheckPos;
    public GameObject MainChar;

    // Start is called before the first frame update
    void Start()
    {
        MainChar = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //when colliding with object, send character back to last referenced checkpoint
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.Find("MC").GetComponent<PlayerCharacterController>().isSliding == false)
        {
            other.transform.position = CheckPos.transform.position;
        }

    }



}