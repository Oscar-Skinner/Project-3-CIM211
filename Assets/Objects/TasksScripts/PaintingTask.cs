using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingTask : MonoBehaviour
{
    public List<TaskObject> taskObject;
    
    public Material pictureChangePhase1;
    public Material pictureChangePhase2;

    public Texture phase1Texture;
    public Texture phase2Texture;
    
    public Texture phase1Original;
    public Texture phase2Original;

    private void Start()
    {
        pictureChangePhase1.mainTexture = phase1Original;
        pictureChangePhase2.mainTexture = phase2Original;
    }

    private void OnEnable()
    {
        foreach (TaskObject task in taskObject)
        {
            task.taskCompleteViewEvent += TaskObjectOntaskCompleteViewEvent;
        }
    }

    private void TaskObjectOntaskCompleteViewEvent()
    {
        pictureChangePhase1.mainTexture = phase1Texture;
        pictureChangePhase2.mainTexture = phase2Texture;
    }
}
