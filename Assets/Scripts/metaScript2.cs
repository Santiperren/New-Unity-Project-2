using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaScript2 : MonoBehaviour
{    
    public float vueltasDos = 0;
    public float checkPointA = 0;
    public float checkPointB = 0;
    public float checkPointC = 0;
    public string autoDos = "autoDos";
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
        if (other.CompareTag(autoDos))
        {
            if (checkPointA == 1 && checkPointB == 1 && checkPointC == 1)
            {
                vueltasDos = 1;
            }
            if (checkPointA == 2 && checkPointB == 2 && checkPointC == 2)
            {
                vueltasDos = 2;
            }
            if (checkPointA == 3 && checkPointB == 3 && checkPointC == 3)
            {
                vueltasDos = 3;
                canMove = false;
                Debug.Log("El jugador dos es el ganador");
            }
        }

    }
}
