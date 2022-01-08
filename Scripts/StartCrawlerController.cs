using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCrawlerController : MonoBehaviour
{
    [SerializeField] public RectTransform CStext;

    // Start is called before the first frame update
    void Start()
    {
        CStext = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        CStext.anchoredPosition += new Vector2(0, 1.5f);
        if (CStext.anchoredPosition.y >= 600)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
