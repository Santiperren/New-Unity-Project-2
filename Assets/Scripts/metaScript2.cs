using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaScript2 : MonoBehaviour
{    
    public float vueltasDos = 0;   
    
   
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
            if (GameManager.Instance.checkPointA == 1 && GameManager.Instance.checkPointB == 1 && GameManager.Instance.checkPointC == 1)
            {
                vueltasDos = 1;
            }
            else if (GameManager.Instance.checkPointA == 2 && GameManager.Instance.checkPointB == 2 && GameManager.Instance.checkPointC == 2)
            {
                vueltasDos = 2;
            }
            else if (GameManager.Instance.checkPointA == 3 && GameManager.Instance.checkPointB == 3 && GameManager.Instance.checkPointC == 3)
            {
                vueltasDos = 3;
                GameManager.Instance.canMove = false;
                Debug.Log("El jugador dos es el ganador");
            }
        }

    }
}
