using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FinalPhase : MonoBehaviour
{
    public List<GameObject> environmentPhase4;
    
    private void Start()
    {
        EnvironmentEnabler(false);
        GameManager.instance.PhaseChangerEvent += InstanceOnPhaseChangerEvent;
    }

    private void InstanceOnPhaseChangerEvent(int obj)
    {
        if (obj == 4)
        {
            EnvironmentEnabler(true);
        }
    }

    public void EnvironmentEnabler(bool enable)
    {
        foreach (GameObject obj in environmentPhase4)
        {
            obj.SetActive(enable);
        }
    }
}
