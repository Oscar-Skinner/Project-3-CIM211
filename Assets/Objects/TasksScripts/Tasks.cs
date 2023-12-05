using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public static Tasks instance;
    
    public bool task1;
    public bool task2;
    public bool task3;
    public bool task4;
    public bool task5;
    
    public event Action<int> TaskCompleteEvent;
    
    void Awake()
    {
        if (instance == null)
        {
            // If not, set the instance to this object
            instance = this;
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    

    public void SetTasksStatus(int taskNumber)
    {
        // Ensure taskNumber is within the valid range
        if (taskNumber >= 1 && taskNumber <= 8)
        {
            // Set the corresponding task boolean based on the taskNumber
            switch (taskNumber)
            {
                case 1:
                    task1 = true;
                    break;
                case 2:
                    task2 = true;
                    break;
                case 3:
                    task3 = true;
                    break;
                case 4:
                    task4 = true;
                    break;
                case 5:
                    task5 = true;
                    break;
            }
        }
        TaskCompleteEvent.Invoke(taskNumber);
        
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }
}
