using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostRampa : MonoBehaviour
{
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
        if (other.CompareTag("autoUno"))
        {
            GameManager.Instance.menosDrag1 = true;
            Debug.Log("hola uno");
            
}
        if (other.CompareTag("autoDos"))
        {
            GameManager.Instance.menosDrag2 = true;
            Debug.Log("hola ");

        }
    }
}
