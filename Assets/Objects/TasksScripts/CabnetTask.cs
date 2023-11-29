using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabnetTask : MonoBehaviour
{
    public List<TaskObject> taskObject;

    public ParticleSystem dustParticle;
    
    private void OnEnable()
    {
        foreach (TaskObject task in taskObject)
        {
            task.taskCompleteViewEvent += TaskObjectOntaskCompleteViewEvent;
        }
    }

    private void TaskObjectOntaskCompleteViewEvent()
    {
        dustParticle.Play();
    }
}
