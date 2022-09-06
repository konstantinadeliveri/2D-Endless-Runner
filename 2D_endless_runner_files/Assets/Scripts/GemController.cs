using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{

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

    //when player character touches gem, play the collect sound, add some number of gems to counter and delete this gem
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GemSound.Play();
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<SphereCollider>().enabled = false;
            TextController.instance.AddGems();
            Destroy(gameObject, 0.6f);
        }

    }
}
