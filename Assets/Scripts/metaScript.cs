using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaScript : MonoBehaviour
{
    public float vueltasUno = 0;
    public GameObject vueltaUno;
    public GameObject vueltaDos;
    public GameObject vueltaTres;
    
    
    // Start is called before the first frame update
    void Start()
    {
        vueltaUno.SetActive(true);
        vueltaDos.SetActive(false);
        vueltaTres.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager.Instance.autoUno))
        {
            GameManager.Instance.checkRespawn = 4;
            if (GameManager.Instance.checkPoint1 == 1 && GameManager.Instance.checkPoint2 == 1 && GameManager.Instance.checkPoint3 == 1)
            {
                vueltasUno++;
                GameManager.Instance.checkPoint1 = 0;
                GameManager.Instance.checkPoint2 = 0;
                GameManager.Instance.checkPoint3 = 0;


            }
            if (vueltasUno == 1)
            {
                vueltaUno.SetActive(false);
                vueltaDos.SetActive(true);
                vueltaTres.SetActive(false);
            }
            if (vueltasUno == 2)
            {
                vueltaUno.SetActive(false);
                vueltaDos.SetActive(false);
                vueltaTres.SetActive(true);
            }
            if (vueltasUno ==3)
            {
                 GameManager.Instance.canMove = false;
                Debug.Log("El jugador uno es el ganador");
            }
        }
        
    }
}
