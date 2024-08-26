using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPU : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float bobbingSpeed = 0.5f;
    public float bobbingHeight = 1f;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float newY = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = startPosition + new Vector3(0, newY, 0);
    }
}
