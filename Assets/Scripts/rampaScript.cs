using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampaScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("AutoUno || AutoDos"))
        {
            Debug.Log("¡El objeto ha pasado por encima!");
            if (collision.gameObject.CompareTag("AutoUno"))
            {
                GameManager.Instance.masVelocidad1 = true;
            }
            if (collision.gameObject.CompareTag("AutoDos"))
            {
                GameManager.Instance.masVelocidad2 = true;
            }
        }
    }
}
