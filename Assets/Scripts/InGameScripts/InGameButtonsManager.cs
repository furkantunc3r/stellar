using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;

    private bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resumeButton()
    {
        StartCoroutine(doScale(pauseCanvas, false));
        isPaused = false;
        Time.timeScale = 1;
    }

    public void mainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void pauseButton()
    {
        if (!isPaused)
        {
            StartCoroutine(doScale(pauseCanvas, true));
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            StartCoroutine(doScale(pauseCanvas, false));
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public IEnumerator doScale(GameObject obj, bool scale)
    {
      
        if (scale)
        {
            pauseCanvas.SetActive(true);
            for (float i = 0; i <= 3; i += Time.unscaledDeltaTime * 4)
            {
                pauseCanvas.GetComponent<CanvasScaler>().scaleFactor = i;
                yield return null;
            }
        }
        else
        {
            for (float i = 3; i >= 0; i -= Time.unscaledDeltaTime * 4)
            {
                pauseCanvas.GetComponent<CanvasScaler>().scaleFactor = i;
                yield return null;
            }
            pauseCanvas.SetActive(false);
        }

    }
}
