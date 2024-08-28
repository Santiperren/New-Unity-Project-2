using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaScript : MonoBehaviour
{
    public float vueltasUno = 0; 
    
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
        if (other.CompareTag(GameManager.Instance.autoUno))
        {
            if (GameManager.Instance.checkPoint1 == 1 && GameManager.Instance.checkPoint2 == 1 && GameManager.Instance.checkPoint3 == 1)
            {
                vueltasUno = 1;
            }
            if (GameManager.Instance.checkPoint1 == 2 && GameManager.Instance.checkPoint2 == 2 && GameManager.Instance.checkPoint3 == 2)
            {
                vueltasUno = 2;
            }
            if (GameManager.Instance.checkPoint1 == 3 && GameManager.Instance.checkPoint2 == 3 && GameManager.Instance.checkPoint3 == 3)
            {
                vueltasUno = 3;
                GameManager.Instance.canMove = false;
                Debug.Log("El jugador uno es el ganador");
            }
        }
        
    }
}
