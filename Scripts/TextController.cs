using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public static int gems = 696969;
    public static int gemVal = 1;
    public static int distVal = 1;
    public float distance = 0;
    public Text gemstext;
    public Text distancetext;
    public static TextController instance;
    public GameObject mainchar;
    public static float DistanceCovered;
    private void Awake()
    {
        instance = this;
        mainchar = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        gemstext.text = "Gems : " + gems.ToString();
        distancetext.text = "Distance : " + DistanceCovered.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCovered = mainchar.transform.position.x * distVal;
        distancetext.text = "Distance : " + DistanceCovered.ToString("F2");
    }

    public void AddGems()
    {
        gems += gemVal;
        gemstext.text = "Gems : " + gems.ToString();
    }

}
