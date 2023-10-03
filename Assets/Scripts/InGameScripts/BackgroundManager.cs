using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgroundPrefabs;
    [SerializeField]
    private GameObject backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        backgroundImage.GetComponent<Image>().sprite = backgroundPrefabs[Random.Range(2, backgroundPrefabs.Length)].GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
