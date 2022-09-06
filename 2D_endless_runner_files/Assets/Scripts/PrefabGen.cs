using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGen : MonoBehaviour
{

    [SerializeField] private Transform ThisPrefab;
    [SerializeField] private List<Transform> PrefabList;
    public GameObject Test1;
    public Vector3 endPos;
    public bool Col = false;

    void Awake()
    {
        endPos = ThisPrefab.Find("PreStart").position;
        endPos.x += 34;
        endPos.y += 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Col == false)
        {
            Instantiate(PrefabList[Random.Range(0, PrefabList.Count)], endPos, Quaternion.identity);
            Col = true;
        }

    }

}
