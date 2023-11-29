using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskStatusManager : MonoBehaviour
{
    public List<ChangingObjects> changingObjectTaskStatus;

    private ChangingObjects beforeTaskCompletion;
    private ChangingObjects afterTaskCompletion;
    
    private void start()
    {
        foreach (ChangingObjects objects in changingObjectTaskStatus)
        {
            if (objects.beforeTask)
            {
                beforeTaskCompletion = objects;
            }
            else
            {
                afterTaskCompletion = objects;
                objects.enabled = false;
            }
        }
    }

//     private void Start()
//     {
//         Tasks.instance.TaskCompleteEvent += InstanceOnTaskCompleteEvent;
//     }
//
//     private void InstanceOnTaskCompleteEvent(int obj)
//     {
//         beforeTaskCompletion.enabled = false;
//         afterTaskCompletion.enabled = true;
//     }
 }
