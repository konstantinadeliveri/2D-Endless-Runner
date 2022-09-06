using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextCrawler : MonoBehaviour
{
    //string for refferencing scene
    public string StartCrawl;
    //static bool for checking if player is playing for the first time
    public static bool firsttime = true;

    // Start is called before the first frame update
    void Awake()
    {
        //if first time playing, show intro text crawl
        if (firsttime == true)
        {
            firsttime = false;
            SceneManager.LoadScene(StartCrawl);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
