using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check3B : MonoBehaviour
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
        if (other.CompareTag(GameManager.Instance.autoDos))
        {
            i++;
            GameManager.Instance.checkRespawn2 = 3;
            GameManager.Instance.checkPointC = 1;
        }

        if (i == 2)
        {
            GameManager.Instance.palmeraMala = true;
        }
    }
}
