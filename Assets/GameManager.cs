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
    private bool gamePlaying;

    public event Action<int> PhaseChangerEvent;

    private void Start()
    {
        // menu stuff
    }

    public void StartGame()
    {
        PhaseChangerEvent?.Invoke(phase);
        gamePlaying = true;
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
        if (gamePlaying)
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

        if (Input.GetKeyDown(KeyCode.G) && gamePlaying == false)
        {
            StartGame();
        }
    }
}
