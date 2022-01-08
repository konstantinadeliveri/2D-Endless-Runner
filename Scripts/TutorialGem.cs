using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGem : MonoBehaviour
{
    //To be used in the tutorial gems

    //variable for the gem collect effect sound
    AudioSource GemSound;

    // Start is called before the first frame update
    void Start()
    {
        //get refference for audiosource component of this gem
        GemSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //just delete the gem when its touched
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GemSound.Play();
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 0.6f);
        }

    }

}
