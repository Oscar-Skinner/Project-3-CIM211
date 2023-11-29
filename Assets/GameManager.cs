using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerModel playermodel;
    
    public List<GameObject> ForgottenObjects;

    public float loadTime;
    public GameObject blackscreen;
    
    
    private float counter;
    private float saveCounter;
    public float phaseLength;
    public int phase = 1;
    private bool gamePlaying;

    public event Action<bool> TaskMenuEvent;
    public event Action<int> PhaseChangerEvent;

    private void Start()
    {
        if (loadTime <= 0)
        {
            loadTime = 1;
        }
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart()
    {
        blackscreen.SetActive(true);
        yield return new WaitForSeconds(loadTime);
        blackscreen.SetActive(false);
        StartTheGame();
    }

    public void StartTheGame()
    {
        PhaseChangerEvent?.Invoke(phase);
        gamePlaying = true;        
        TaskMenuEvent?.Invoke(gamePlaying);
    }

    public void TaskMenuOpen()
    {
        if (gamePlaying)
        {
            saveCounter = counter;
            gamePlaying = false;
            TaskMenuEvent?.Invoke(gamePlaying);
        }
        else
        {
            gamePlaying = true;
            counter = saveCounter;
            TaskMenuEvent?.Invoke(gamePlaying);
        }
    }

    public void ProgressPhase()
    {
        if (phase <= 3)
        {
            phase += 1;
                    
            PhaseChangerEvent?.Invoke(phase);
            Forget();
            playermodel.blinkFunction();
                    
            counter = 0;
        }
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
    }
}
