using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaScript : MonoBehaviour
{
    public float vueltasUno = 0;    
    public float checkPoint1 = 0;
    public float checkPoint2 = 0;
    public float checkPoint3 = 0;
    public string autoUno = "autoUno";
    public bool canMove = false;
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
            if (GameManager.Instance.check1 == 1 && checkPoint2 == 1 && checkPoint3 == 1)
            {
                vueltasUno = 1;
            }
            if (checkPoint1 == 2 && checkPoint2 == 2 && checkPoint3 == 2)
            {
                vueltasUno = 2;
            }
            if (checkPoint1 == 3 && checkPoint2 == 3 && checkPoint3 == 3)
            {
                vueltasUno = 3;
                canMove = false;
                Debug.Log("El jugador uno es el ganador");
            }
        }
        
    }
}
