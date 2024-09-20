using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check1 : MonoBehaviour
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
        if (other.CompareTag(GameManager.Instance.autoUno))
        {
            GameManager.Instance.checkRespawn = 1;
            GameManager.Instance.checkPoint1 = 1;
            
        }
        
    }
}
