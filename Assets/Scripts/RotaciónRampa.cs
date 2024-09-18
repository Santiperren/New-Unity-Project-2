using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaciónRampa : MonoBehaviour
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
            GameManager.Instance.rotate01 = true;

        }
        if (other.CompareTag(GameManager.Instance.autoDos))
        {
            GameManager.Instance.rotate02 = true;


        }
    }
}
