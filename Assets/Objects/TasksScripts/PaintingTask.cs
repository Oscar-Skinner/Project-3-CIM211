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
        if (GameManager.instance.phase == 1)
        {
            GetComponentInParent<MeshRenderer>().material = pictureChangePhase1;
        }
        if (GameManager.instance.phase == 2)
        {
            GetComponentInParent<MeshRenderer>().material = pictureChangePhase2;
        }
    }
}
