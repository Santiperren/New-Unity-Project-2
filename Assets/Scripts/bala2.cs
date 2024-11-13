using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala2 : MonoBehaviour
{
    public GameObject puntoDedisparo;
    public float velocidadBala = 17000f;
    public Rigidbody bodi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bodi != null)
        {
            bodi.velocity = puntoDedisparo.forward * velocidadBala; 
        }
    }
}
