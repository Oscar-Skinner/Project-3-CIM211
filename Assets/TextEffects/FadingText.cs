using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadingText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fadeDuration;
    
    private void Start()
    {
        StartCoroutine(ImageFadeIn());
    }
    
    private IEnumerator ImageFadeIn()
    {
        float elapsedTime = 0f;
        Color startColor = text.color;
        
        text.enabled = true;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            startColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            text.color = startColor;
            
            yield return null;
        }

        yield return new WaitForSeconds(fadeDuration);
        StartCoroutine(ImageFadeOut());
    }
    
    private IEnumerator ImageFadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = text.color;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            startColor.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeDuration);
            text.color = startColor;
            
            yield return null;
        }
        
        text.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        
        SceneManager.LoadScene(0);
    }
    
}
