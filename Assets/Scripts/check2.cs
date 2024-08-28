using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check2 : MonoBehaviour
{
    public float checkPoint2 = 0;
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
            if (checkPoint2 == 0)
            {
                checkPoint2 = 1;
            }
            else if (checkPoint2 == 1)
            {
                checkPoint2 = 2;
            }
            else if (checkPoint2 == 2)
            {
                checkPoint2 = 3;
            }
        }
        
    }
}
