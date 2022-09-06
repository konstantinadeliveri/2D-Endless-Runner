using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // it's the 2nd button in store menu... upgrades gems text by one when pressed
    public void UpgradeDs()
    {
        if(TextController.gems >= 100)
        {
            TextController.gems += -100;
            TextController.gemVal += 1;
        }
    }

}
