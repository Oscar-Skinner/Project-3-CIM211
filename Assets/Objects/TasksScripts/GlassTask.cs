using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTask : MonoBehaviour
{
    public List<TaskObject> taskObject;

    public GameObject parentObject;
    private void OnEnable()
    {
        foreach (TaskObject task in taskObject)
        {
            task.taskCompleteViewEvent += TaskOntaskCompleteViewEvent;
        }
    }

    private void TaskOntaskCompleteViewEvent()
    {
        Destroy(parentObject);
    }
}
