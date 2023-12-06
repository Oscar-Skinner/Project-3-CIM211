using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public TextMeshProUGUI titleText;
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;
    
    public Image blackImage;
    private bool fadeBool = true;
    public float fadeDuration;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(ImageFadeOut());
        titleText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    private IEnumerator ImageFadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = blackImage.color;
        
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            startColor.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeDuration);
            blackImage.color = startColor;
            
            yield return null;
        }
        
        blackImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        
        blackImage.enabled = false;
    }
    private IEnumerator ImageFadeIn()
    {
        float elapsedTime = 0f;
        Color startColor = blackImage.color;
        
        blackImage.enabled = true;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            
            startColor.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            blackImage.color = startColor;
            
            yield return null;
        }
        
        blackImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        
        SceneManager.LoadScene(2);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsMenu()
    {
        //StartCoroutine(ImageFadeIn());
        SceneManager.LoadScene(2);
    }
    
    
    public void CloseMenu()
    {
        Application.Quit();
    }
}
