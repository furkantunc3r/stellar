using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image backgroundImg;
    private MenuButtonsManager menuManager;

    [SerializeField]
    private GameObject buttonsCanvas;

    private float min;
    private float max;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("MenuButtonsManager").GetComponent<MenuButtonsManager>();
        StartCoroutine(menuManager.FadeImage(buttonsCanvas, true));
        min = backgroundImg.transform.position.x - 100f;
        max = backgroundImg.transform.position.x + 100f;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImg.transform.position = new Vector3(Mathf.Lerp(min, max, time), backgroundImg.transform.position.y, 0);
        time += 0.5f * Time.deltaTime;
        if (time > 1.0f)
        {
            float temp = max;
            max = min;
            min = temp;
            time = 0.0f;
        }
    }
}
