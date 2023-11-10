using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public List<GameObject> ForgottenObjects;
    
    public void Forget()
    {
        foreach (GameObject obj in ForgottenObjects)
        {
            if (obj.GetComponent<ChangingObjects>() != null)
            {
                obj.GetComponent<ChangingObjects>().Disappear();
            }
        }
    }
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
