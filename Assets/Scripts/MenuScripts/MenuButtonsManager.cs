using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject aboutPanel;

    bool isPanelOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void playButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void settingsButton()
    {

    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void aboutButton()
    {
        if (!isPanelOpen)
            StartCoroutine(FadeImage(aboutPanel, true));
        else
            StartCoroutine(FadeImage(aboutPanel, false));
        isPanelOpen = !isPanelOpen;
    }


    public IEnumerator FadeImage(GameObject obj, bool fadeIn)
    {
        if (fadeIn)
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                obj.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                obj.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
        }
    }
}
