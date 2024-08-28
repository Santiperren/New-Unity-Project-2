using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check1B : MonoBehaviour
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
            if (GameManager.Instance.checkPointA == 0)
            {
                GameManager.Instance.checkPointA = 1;
            }
            else if (GameManager.Instance.checkPointA == 1)
            {
                GameManager.Instance.checkPointA = 2;
            }
            else if (GameManager.Instance.checkPointA == 2)
            {
                GameManager.Instance.checkPointA = 3;
            }
        }

    }
}
