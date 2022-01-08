using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when called (probably when button the script is assigned to is pressed), check if player has enough gems to afford, and if game isn't too fast already. if both true, remove gems, make game faster
    public void SpeedUpgrade()
    {
        if (TextController.gems >= 50 && Time.timeScale <= 0.80f)
        {
            TextController.gems += -50;
            Time.timeScale += 0.15f;
        }
    }
}
