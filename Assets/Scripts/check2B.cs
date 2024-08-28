using System.Collections;
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
            if (GameManager.Instance.checkPointB == 0)
            {
                GameManager.Instance.checkPointB = 1;
            }
            else if (GameManager.Instance.checkPointB == 1)
            {
                GameManager.Instance.checkPointB = 2;
            }
            else if (GameManager.Instance.checkPointB == 2)
            {
                GameManager.Instance.checkPointB = 3;
            }
        }

    }
}
