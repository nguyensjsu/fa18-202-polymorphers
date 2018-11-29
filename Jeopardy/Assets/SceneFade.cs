using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    /*public float fadeSpeed;
    private CanvasGroup canvasGroup;

    // Use this for initialization
    private void Awake()
    {
        GameObject.Find("CreateGameCanvas").GetComponent<CanvasGroup>().alpha = 0;
    }

    void Start ()
    {
        canvasGroup = GameObject.Find("CreateGameCanvas").GetComponent<CanvasGroup>();
        FadeIn();
	}

    public void FadeIn()
    {
        StartCoroutine(IFadeIn());
    }

    public void FadeOut(string scenename)
    {
        StartCoroutine(IFadeOut(scenename));
    }

    IEnumerator IFadeIn()
    {
        float alpha = 0.0f;

        while(alpha < 1.0f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }

   
    }

    IEnumerator IFadeOut(string scene)
    {
        float alpha = 1.0f;

        while (alpha > 0.0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = alpha;
            yield return null;
        }
        //scene change
        SceneManager.LoadScene(scene);
    }*/
    

}
