﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check2B : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager.Instance.autoDos))
        {
            GameManager.Instance.checkRespawn2 = 2;
            GameManager.Instance.checkPointB = 1;
        }

    }
}
