using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramaphoneTask : MonoBehaviour
{
    public List<TaskObject> taskObject;

    private void OnEnable()
    {
        foreach (TaskObject task in taskObject)
        {
            task.taskCompleteViewEvent += TaskOntaskCompleteViewEvent;
        }
    }

    private void TaskOntaskCompleteViewEvent()
    {
        foreach (TaskObject taskObject in taskObject)
        {
            taskObject.complete = false;
        }
        GameManager.instance.ProgressPhase();
    }
}
