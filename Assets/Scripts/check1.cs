using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check1 : MonoBehaviour
{
    public float checkPoint1 = 0;
    public string autoUno = "autoUno";
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
        if (other.CompareTag(autoUno))
        {
            if (checkPoint1 == 0)
            {
                checkPoint1 = 1;
            }
            else if (checkPoint1 == 1)
            {
                checkPoint1 = 2;
            }
            else if (checkPoint1 == 2)
            {
                checkPoint1 = 3;
            }
        }
        
    }
}
