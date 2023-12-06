using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TasksView : MonoBehaviour
{
    public Tasks tasksModel;
    
    public string task1;
    public string task2;
    public string task3;
    public string task4;
    public string task5;

    public GameObject taskMenuCanvas;
    public TextMeshProUGUI tmpTask1;
    public TextMeshProUGUI tmpTask2;
    public TextMeshProUGUI tmpTask3;
    public TextMeshProUGUI tmpTask4;
    public TextMeshProUGUI tmpTask5;
    
    
    private void OnEnable()
    {
        tasksModel.TaskCompleteEvent += TasksModelOnTaskCompleteEvent;
    }

    private void InstanceTaskMenuEvent(bool taskMenuOpen)
    {
        taskMenuCanvas.SetActive(!taskMenuOpen);
    }

    private void Start()
    {
        GameManager.instance.TaskMenuEvent += InstanceTaskMenuEvent;
        GameManager.instance.PhaseChangerEvent += InstanceOnPhaseChangerEvent;
        
        if (tmpTask1 != null)
        {
            tmpTask1.text = task1;
        }
        if (tmpTask2 != null)
        {
            tmpTask2.text = task2;
        }
        if (tmpTask3 != null)
        {
            tmpTask3.text = task3;
        }
        if (tmpTask4 != null)
        {
            tmpTask4.text = task4;
        }
        if (tmpTask5 != null)
        {
            tmpTask5.text = task5;
        }
    }

    private void InstanceOnPhaseChangerEvent(int obj)
    {
        if (obj == 4)
        {
            tmpTask1.text = task5;
            tmpTask2.text = task5;
            tmpTask3.text = task5;
            tmpTask4.text = task5;
        }
    }

    private void TasksModelOnTaskCompleteEvent(int num)
    {
        if (num >= 1 && num <= 8)
        {
            switch (num)
            {
                case 1:
                    tmpTask1.fontStyle = FontStyles.Strikethrough;
                    break;
                case 2:
                    tmpTask2.fontStyle = FontStyles.Strikethrough;                    
                    break;
                case 3:
                    tmpTask3.fontStyle = FontStyles.Strikethrough;                    
                    break;
                case 4:
                    tmpTask4.fontStyle = FontStyles.Strikethrough;                    
                    break;
                case 5:
                    tmpTask5.fontStyle = FontStyles.Strikethrough;                    
                    break;
            }
        }    
    }
}
