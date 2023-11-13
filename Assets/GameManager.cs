using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerModel playermodel;
    
    public List<GameObject> ForgottenObjects;

    private float counter;
    public float phaseLength;
    private int phase = 1;

    public event Action<int> PhaseChangerEvent;

    private void Start()
    {
        PhaseChangerEvent?.Invoke(phase);
    }

    public void Forget()
    {
        foreach (GameObject obj in ForgottenObjects)
        {
            if (obj.GetComponent<ChangingObjects>() != null)
            {
                obj.GetComponent<ChangingObjects>().Disappear(phase);
            }
        }
    }

    public void ForgetSpecific(ChangingObjects forgetObj)
    {
        forgetObj.Disappear(phase);
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
        counter += Time.deltaTime;

        if (counter >= phaseLength)
        {
            if (phase <= 3)
            {
                phase += 1;
                
                PhaseChangerEvent?.Invoke(phase);
                Forget();
                playermodel.blinkFunction();
                
                counter = 0;
            }
            else
            {
                print("end");
            }
            print(phase);
        }
    }
}
