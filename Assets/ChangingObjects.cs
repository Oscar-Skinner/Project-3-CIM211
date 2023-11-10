using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangingObjects : MonoBehaviour
{
    public List<GameObject> objectsList = new List<GameObject>();
    private List<GameObject> disappearedObjects = new List<GameObject>();
    private List<GameObject> appearedObjects = new List<GameObject>();

    private void Start()
    {
        Disappear();
    }
    
    public void Disappear()
    {
        disappearedObjects.Clear();
        foreach (GameObject obj in objectsList)
        {
            obj.SetActive(false);
            disappearedObjects.Add(obj);
        }

        // Randomly appear one object
        Reappear();
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