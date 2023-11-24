using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public Image topEyeLid;
    public Image bottomEyeLid;

    public AudioSource gramaphoneSource;

    public List<AudioClip> musicPhases;
    private int chosenClip;
    
    public Animation animation;

    private bool isBlinking = false;
    
    public PlayerModel blinkingModel;
    private void Start()
    {
        blinkingModel.blinkEvent += BlinkFunction;
        GameManager.instance.PhaseChangerEvent += InstanceOnPhaseChangerEvent;
    }

    private void InstanceOnPhaseChangerEvent(int obj)
    {
        if (obj <= 3)
        {
            gramaphoneSource.clip = musicPhases[obj - 1];
            gramaphoneSource.Play();
        }
        else
        {
            gramaphoneSource.Stop();
        }
    }

    public void BlinkFunction()
    {
        animation.Play();
    }
}
