using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check3 : MonoBehaviour
{
    public int i = 0;
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
            GameManager.Instance.checkRespawn = 3;
            GameManager.Instance.checkPoint3 = 1;
            
        }
        if (i == 2)
        {
            GameManager.Instance.palmeraMala = true;
        }

    }
}

