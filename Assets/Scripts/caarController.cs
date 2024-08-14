using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caarController : MonoBehaviour
{
    public Rigidbody theRB;
    public float aceleracion = 8f, reversa = 4f, maxSpeed = 50f, turnStrenght = 180f, gravityForce = 10f, dragOnGround = 3f;

    private float speedInput, turnInput;
    private bool alPiso;
    public LayerMask estaEnElPiso;
    public float groungRayLenght = 0.5f;
    public Transform groundRayPoint;
    public Transform ruedaAdelanteIzquierda, ruedaAdelanteDerecha;
    public float maxGiroRueda = 25f;
    public ParticleSystem[] dustTrial;
    public float maxEmission = 25f;
    private float emissionRate;
    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;// AAAAAAAAAAAAAAAAAAAAAAAAAAAA mal con razon, aaaaa, soy fan de campa
        
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if (Input.GetAxis("WS") > 0)
        {
            speedInput = Input.GetAxis("WS") * aceleracion * 1000f;
        }
        else if (Input.GetAxis("WS") < 0)
        {
            speedInput = Input.GetAxis("WS") * reversa * 1000f;
        }
        turnInput = Input.GetAxis("AD");
        if (alPiso)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("WS"), 0f));
        }

        ruedaAdelanteDerecha.localRotation = Quaternion.Euler(ruedaAdelanteDerecha.localRotation.eulerAngles.x, (turnInput * maxGiroRueda) - 180, ruedaAdelanteDerecha.rotation.eulerAngles.z);
        ruedaAdelanteIzquierda.localRotation = Quaternion.Euler(ruedaAdelanteIzquierda.localRotation.eulerAngles.x, turnInput * maxGiroRueda, ruedaAdelanteIzquierda.rotation.eulerAngles.z);
        transform.position = theRB.transform.position;

    }
    private void FixedUpdate()
    {
        // theRB.AddForce(transform.forward * aceleracion * 1000f);
        alPiso = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groungRayLenght, estaEnElPiso))
        {
            alPiso = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        emissionRate = 0;
        if (alPiso)
        {
            theRB.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                theRB.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;
            }
        }
        else
        {
            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
        foreach (ParticleSystem part in dustTrial)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
}
