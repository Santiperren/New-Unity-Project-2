using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check3 : MonoBehaviour
{
    public float checkPoint3 = 0;
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
            if (checkPoint3 == 0)
            {
                checkPoint3 = 1;
            }
            else if (checkPoint3 == 1)
            {
                checkPoint3 = 2;
            }
            else if (checkPoint3 == 2)
            {
                checkPoint3 = 3;
            }
        }
    }
}
