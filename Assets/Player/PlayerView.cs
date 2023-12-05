using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public Image topEyeLid;
    public Image bottomEyeLid;

    public TextMeshProUGUI instructions;
    public TextMeshProUGUI finalText;
    
    public AudioSource gramaphoneSource;

    public List<AudioClip> musicPhases;
    private int chosenClip;
    
    public Animation animation;

    private bool isBlinking = false;
    
    public PlayerModel blinkingModel;
    private void Start()
    {
        finalText.enabled = false;
        blinkingModel.blinkEvent += BlinkFunction;
        GameManager.instance.PhaseChangerEvent += InstanceOnPhaseChangerEvent;
    }

    private void InstanceOnPhaseChangerEvent(int obj)
    {
        if (obj <= 4)
        {
            gramaphoneSource.clip = musicPhases[obj - 1];
            gramaphoneSource.Play();
        }
        else
        {
            gramaphoneSource.Stop();
            
        }
        
        if (obj == 3)
        {
            gramaphoneSource.spatialBlend = .5f;
        }
        
        if (obj >= 4)
        {
            gramaphoneSource.spatialBlend = 0;
        }

        if (obj == 4)
        {
            instructions.enabled = false;
            finalText.enabled = true;
            StartCoroutine(TypeText());
        }
    }

    public void BlinkFunction()
    {
        animation.Play();
    }
    
    
    public float typingSpeed;
    [TextArea(3,10)]
    public string textToType;
    public TextMeshProUGUI displayText;

    IEnumerator TypeText()
    {
        foreach (char letter in textToType)
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
