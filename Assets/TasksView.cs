using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksView : MonoBehaviour
{
    public Tasks tasksModel;
    
    // need to add canvas UI stuff here
    
    public string task1;
    public string task2;
    public string task3;
    public string task4;
    public string task5;
    public string task6;
    public string task7;
    public string task8;

    private void Start()
    {
        tasksModel.TaskCompleteEvent += TasksModelOnTaskCompleteEvent;
    }

    private void TasksModelOnTaskCompleteEvent(int num)
    {
        if (num >= 1 && num <= 8)
        {
            switch (num)
            {
                // instead of the strings = the name it will just turn the non-completed tasks off/cross them off
                case 1:
                    task1 = "task1";
                    break;
                case 2:
                    task2 = "task2";
                    break;
                case 3:
                    task3 = "task3";
                    break;
                case 4:
                    task4 = "task4";
                    break;
                case 5:
                    task5 = "task5";
                    break;
                case 6:
                    task6 = "task6";
                    break;
                case 7:
                    task7 = "task7";
                    break;
                case 8:
                    task8 = "task8";
                    break;
            }
        }    
    }
}
