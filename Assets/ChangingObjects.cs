using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ChangingObjects : MonoBehaviour
{
    public bool beforeTask;
    
    public List<GameObject> objectsListPhase1 = new List<GameObject>();
    public List<GameObject> objectsListPhase2 = new List<GameObject>();
    public List<GameObject> objectsListPhase3 = new List<GameObject>();
    
    private List<GameObject> disappearedObjects = new List<GameObject>();
    private List<GameObject> appearedObjects = new List<GameObject>();
    
    private int phase = 1;
    private void Start()
    {
        SetObjectInvisible();
        
        Disappear(phase);
    }

    private void OnEnable()
    {
        SetObjectInvisible();
        
        Disappear(phase);
    }

    private void OnDisable()
    {
        SetObjectInvisible();
    }

    public void Disappear(float phase)
    {
        phase = this.phase;
        
        disappearedObjects.Clear();
        
        SetObjectInvisible();
        
        if (phase == 1)
        {
            foreach (GameObject obj in objectsListPhase1)
            {
                disappearedObjects.Add(obj);
            }
        }
        if (phase == 2)
        {
            foreach (GameObject obj in objectsListPhase2)
            {
                disappearedObjects.Add(obj);
            }
        }
        if (phase == 3)
        {
            foreach (GameObject obj in objectsListPhase3)
            {
                disappearedObjects.Add(obj);
            }
        }
        
        // Randomly appear one object
        Reappear();
    }

    public void SetObjectInvisible()
    {
        foreach (GameObject obj in objectsListPhase1)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsListPhase2)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in objectsListPhase3)
        {
            obj.SetActive(false);
        }
    }
    
    public void Reappear()
    {
        appearedObjects.Clear();
        if (disappearedObjects.Count > 0)
        {
            // Choose a random object to appear
            int randomIndex = Random.Range(0, disappearedObjects.Count);
            GameObject randomObject = disappearedObjects[randomIndex];

            // Enable the chosen object
            randomObject.SetActive(true);

            // Move the object from disappeared to appeared list
            disappearedObjects.Remove(randomObject);
            appearedObjects.Add(randomObject);
        }
    }
}