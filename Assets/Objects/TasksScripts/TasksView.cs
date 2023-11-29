using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject taskMenuCanvas;
    public TextMeshProUGUI tmpTask1;
    public TextMeshProUGUI tmpTask2;
    public TextMeshProUGUI tmpTask3;
    public TextMeshProUGUI tmpTask4;
    public TextMeshProUGUI tmpTask5;
    public TextMeshProUGUI tmpTask6;
    public TextMeshProUGUI tmpTask7;
    public TextMeshProUGUI tmpTask8;

    
    private void OnEnable()
    {
        tasksModel.TaskCompleteEvent += TasksModelOnTaskCompleteEvent;
        GameManager.instance.TaskMenuEvent += InstanceTaskMenuEvent;
    }

    private void InstanceTaskMenuEvent(bool taskMenuOpen)
    {
        taskMenuCanvas.SetActive(!taskMenuOpen);
    }

    private void Start()
    {
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
        if (tmpTask6 != null)
        {
            tmpTask6.text = task6;
        }
        if (tmpTask7 != null)
        {
            tmpTask7.text = task7;
        }
        if (tmpTask8 != null)
        {
            tmpTask8.text = task8;
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
                case 6:
                    tmpTask6.fontStyle = FontStyles.Strikethrough;                    
                    break;
                case 7:
                    tmpTask7.fontStyle = FontStyles.Strikethrough;                    
                    break;
                case 8:
                    tmpTask8.fontStyle = FontStyles.Strikethrough;                    
                    break;
            }
        }    
    }
}
