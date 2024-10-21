using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaScript2 : MonoBehaviour
{    
    public float vueltasDos = 0;
    public GameObject vueltaUnoB;
    public GameObject vueltaDosB;
    public GameObject vueltaTresB;
    public float vueltasUno = 0;
    public GameObject vueltaUno;
    public GameObject vueltaDos;
    public GameObject vueltaTres;
    public GameObject finish;
    public GameObject finish2;



    // Start is called before the first frame update
    void Start()
    {
        vueltaUnoB.SetActive(true);
        vueltaDosB.SetActive(false);
        vueltaTresB.SetActive(false);

        vueltaUno.SetActive(true);
        vueltaDos.SetActive(false);
        vueltaTres.SetActive(false);
        finish.SetActive(false);
        finish2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager.Instance.autoDos))
        {
            GameManager.Instance.checkRespawn2 = 4;
            if (GameManager.Instance.checkPointA == 1 && GameManager.Instance.checkPointB == 1 && GameManager.Instance.checkPointC == 1)
            {
                vueltasDos++;
                GameManager.Instance.checkPointA = 0;
                GameManager.Instance.checkPointB = 0;
                GameManager.Instance.checkPointC = 0;
                Debug.Log("autotecla");
            }
            if (vueltasDos == 1)
            {                
                vueltaUnoB.SetActive(false);
                vueltaDosB.SetActive(true);
                vueltaTresB.SetActive(false);
                GameManager.Instance.palmeraMala = true;
            }
            if (vueltasDos == 2)
            {
                GameManager.Instance.canMove = false;
                Debug.Log("El jugador dos es el ganador");

                finish2.SetActive(true);
            }
            if (vueltasDos ==3)
            { 
                
                GameManager.Instance.canMove = false;
                Debug.Log("El jugador dos es el ganador");
                finish2.SetActive(true);
            }
        }
        if (other.CompareTag(GameManager.Instance.autoUno))
        {
            Debug.Log("aprimer if");
            GameManager.Instance.checkRespawn = 4;
            if (GameManager.Instance.checkPoint1 == 1 && GameManager.Instance.checkPoint2 == 1 && GameManager.Instance.checkPoint3 == 1)
            {
                vueltasUno++;
                GameManager.Instance.checkPoint1 = 0;
                GameManager.Instance.checkPoint2 = 0;
                GameManager.Instance.checkPoint3 = 0;
                Debug.Log("autojoysrtick");
            }
            if (vueltasUno == 1)
            {                
                vueltaUno.SetActive(false);
                vueltaDos.SetActive(true);
                vueltaTres.SetActive(false);
                GameManager.Instance.palmeraMala = true;
            }
            if (vueltasUno == 2)
            {
                GameManager.Instance.canMove = false;
                Debug.Log("El jugador uno es el ganador");                
                finish.SetActive(true);
            }
            if (vueltasUno == 3)
            {
                GameManager.Instance.canMove = false;
                Debug.Log("El jugador uno es el ganador");
                finish.SetActive(true);
            }
            
        }

    }
}
