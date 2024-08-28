using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check3 : MonoBehaviour
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
        if (other.CompareTag(GameManager.Instance.autoUno))
        {
            if (GameManager.Instance.checkPoint3 == 0)
            {
                GameManager.Instance.checkPoint3 = 1;
            }
            else if (GameManager.Instance.checkPoint3 == 1)
            {
                GameManager.Instance.checkPoint3 = 2;
            }
            else if (GameManager.Instance.checkPoint3 == 2)
            {
                GameManager.Instance.checkPoint3 = 3;
            }
        }
    }
}
