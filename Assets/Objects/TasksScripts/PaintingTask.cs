using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingTask : MonoBehaviour
{
    public List<TaskObject> taskObject;

    public Material pictureChangePhase1;
    public Material pictureChangePhase2;
    
    private void OnEnable()
    {
        foreach (TaskObject task in taskObject)
        {
            task.taskCompleteViewEvent += TaskObjectOntaskCompleteViewEvent;
        }
    }

    private void TaskObjectOntaskCompleteViewEvent()
    {
        //do it based on phases
        GetComponentInParent<MeshRenderer>().material = pictureChangePhase1;
    }
}
