using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{
    public int TaskNumber;
    public bool complete;
    public void TickOffTask()
    {
        Tasks.instance.SetTasksStatus(TaskNumber);
        TaskTickOff();
    }

    public event Action taskCompleteViewEvent;
    
    public void TaskTickOff()
    {
        if (complete == false)
        {
            taskCompleteViewEvent?.Invoke();
            complete = true;
        }
    }
}
