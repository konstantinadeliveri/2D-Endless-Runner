using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //variable for the chase music
    AudioSource ChaseSound;

    //refference character // NOT OURS, TAKEN FROM INTERNET
    [SerializeField] private Transform target = null;

    private Vector3 offset;
     
    // Start is called before the first frame update
    void Start()
    {
        //get refference for audiosource component of this object
        ChaseSound = GetComponent<AudioSource>();
        //start music if not muted
        if (SoundManager.muted == false)
        {
            ChaseSound.Play();
        }
        //move camera to the position of the player at start // NOT OURS, TAKEN FROM INTERNET
        offset = transform.position - target.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //keep moving camera as character moves. Lerp makes it smoother // NOT OURS, TAKEN FROM INTERNET
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, target.position.z) + offset, Time.deltaTime * 3);
    }
}
