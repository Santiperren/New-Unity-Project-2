using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tibuGira : MonoBehaviour
{
    public float rotacion = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float animation = rotacion * Time.deltaTime;
        transform.Rotate(0, animation, 0);
    }
}
