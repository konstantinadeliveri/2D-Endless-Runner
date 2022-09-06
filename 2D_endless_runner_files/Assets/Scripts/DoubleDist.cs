using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // it's the 3rd button in store menu... upgrades distance text by one when pressed
    public void UpgradeDist()
    {
        if(TextController.gems >= 100)
        {
            TextController.gems += -100;
            TextController.distVal += 1;
        }
    }

}