using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour {

    #region Singleton
    private static SceneMove instance;
    public static SceneMove Instance
    {
        get
        {
            return instance;
        }
    }

    #endregion          //SceneMove 스크립트의 싱글톤 선언 언제나 SceneMove.Instance로 불러올 수 있음

    public Image FadeImage;
    public float FadeSpeed;
    public bool IsFadeIn;

    private void Awake()
    {
        instance = this;
        if(IsFadeIn)
            StartCoroutine(FadeIn());
    }

    public void Move(string SceneName)
    {
        StartCoroutine(FadeOut(SceneName));
    }

    public IEnumerator FadeIn()
    {
        FadeImage.color = new Color(0, 0, 0, 1);
        while (FadeImage.color.a >= 0)
        {
            FadeImage.enabled = true;
            FadeImage.color -= new Color(0, 0, 0, FadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public IEnumerator FadeOut(string SceneName)
    {
        FadeImage.enabled = true;
        FadeImage.color = new Color(0,0, 0, 0);
        while (FadeImage.color.a <= 1)
        {
            FadeImage.color += new Color(0, 0, 0, FadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }
        SceneManager.LoadScene(SceneName);

        yield return null;
    }

    public IEnumerator FadeOut()
    {
        FadeImage.enabled = true;
        while (FadeImage.color.a <= 1)
        {
            FadeImage.color += new Color(0, 0, 0, FadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
