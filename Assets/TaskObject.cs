using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskObject : MonoBehaviour
{
    public int TaskNumber;

    public void TickOffTask()
    {
        Tasks.instance.SetTasksStatus(TaskNumber);
    }
    
}
