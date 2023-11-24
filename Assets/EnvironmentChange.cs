using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnvironmentChange : MonoBehaviour
{
    public GameObject environmentObj1;
    public GameObject environmentObj2;
    public GameObject environmentObj3;

    public Material environmentMat2;
    public Material environmentMat3;

    public int phase;
    
    private void Start()
    {
        GameManager.instance.PhaseChangerEvent += InstanceOnPhaseChangerEvent;
    }

    private void InstanceOnPhaseChangerEvent(int obj)
    {
        phase = obj;
        Change();
    }

    #region CheckAvailableObjects

    public bool enviroObj1Check()
    {
        if (environmentObj1 != null)
        {
            return true;
        }

        return false;
    }
    
    public bool enviroObj2Check()
    {
        if (environmentObj2 != null)
        {
            return true;
        }

        return false;
    }

    public bool enviroObj3Check()
    {
        if (environmentObj3 != null)
        {
            return true;
        }

        return false;
    }
    
    public bool enviroMat2Check()
    {
        if (environmentMat2 != null)
        {
            return true;
        }

        return false;
    }
    
    public bool enviroMat3Check()
    {
        if (environmentMat3 != null)
        {
            return true;
        }

        return false;
    }
    
    #endregion
    
    
    public void Change()
    {
        if (phase == 1)
        {
            DisableAll();
            if (enviroObj1Check())
            {
                if (environmentObj1.activeInHierarchy == false)
                {
                    environmentObj1.SetActive(true);
                }
            }
        }
        if (phase == 2)
        {
            if (enviroObj2Check())
            {
                environmentObj1.SetActive(false);
                environmentObj2.SetActive(true);
            }
            else if (enviroMat2Check())
            {
                environmentObj1.GetComponent<MeshRenderer>().material = environmentMat2;
            }
        }
        if (phase == 3)
        {
            if (enviroObj3Check())
            {
                
                DisableAll();
                environmentObj3.SetActive(true);
                
            }
            else if (enviroMat3Check())
            {
                if (environmentObj1.activeInHierarchy)
                {
                    environmentObj1.GetComponent<MeshRenderer>().material = environmentMat3;

                }
                if (enviroObj2Check())
                {
                    if (environmentObj2.activeInHierarchy)
                    {
                        environmentObj2.GetComponent<MeshRenderer>().material = environmentMat3;
                    }
                }
            }
        }
        if (phase >= 4)
        {
            DisableAll();
        }
    }
    
    public void DisableAll()
    {
        if (enviroObj1Check())
        {
            environmentObj1.SetActive(false);
        }

        if (enviroObj2Check())
        {
            environmentObj2.SetActive(false);
        }

        if (enviroObj3Check())
        {
            environmentObj3.SetActive(false);
        }
    }
}
