using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check1B : MonoBehaviour
{
    public float checkPointA = 0;
    public string autoDos = "autoDos";
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
        if (other.CompareTag(autoDos))
        {
            if (checkPointA == 0)
            {
                checkPointA = 1;
            }
            else if (checkPointA == 1)
            {
                checkPointA = 2;
            }
            else if (checkPointA == 2)
            {
                checkPointA = 3;
            }
        }

    }
}
