using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingView : MonoBehaviour
{
    public Image topEyeLid;
    public Image bottomEyeLid;

    public Animation animation;

    private bool isBlinking = false;

    public PlayerModel blinkingModel;
    private void Start()
    {
        blinkingModel.blinkEvent += BlinkFunction;
    }
    
    public void BlinkFunction()
    {

        animation.Play();

    }
}
