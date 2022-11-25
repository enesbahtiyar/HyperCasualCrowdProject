using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    [Header(" Settings ")]
    private bool isTarget;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public bool IsTarget()
    {
        return isTarget;
    }

    public void SetTarget()
    {
        isTarget = true;
    }
}
