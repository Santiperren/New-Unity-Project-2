using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check3B : MonoBehaviour
{
    public float checkPointC = 0;
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
            if (checkPointC == 0)
            {
                checkPointC = 1;
            }
            else if (checkPointC == 1)
            {
                checkPointC = 2;
            }
            else if (checkPointC == 2)
            {
                checkPointC = 3;
            }
        }

    }
}
