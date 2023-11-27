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
    public Button returnButton;
    public TextMeshProUGUI creditsText;

    private void Start()
    {
        titleText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        
        returnButton.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsMenu()
    {
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        
        returnButton.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(true);
    }

    public void ReturnButtonClick()
    {
        titleText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        
        returnButton.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(false);
    }
    
    
    public void CloseMenu()
    {
        Application.Quit();
    }
}
