using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caarController : MonoBehaviour
{
    public Rigidbody theRB;
    public float aceleracion = 17f, reversa = 6f, maxSpeed = 3200f, turnStrenght = 200f, gravityForce = 10f, dragOnGround = 3f;
    
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
    public float desapareceTiempo = 5f;
    private float cuentaRegresiva;
    public bool powerUpActivado2 = false;
    public float powerUpSpeedDuracion2 = 5f;
    private float powerUpActivadoFin2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;// AAAAAAAAAAAAAAAAAAAAAAAAAAAA mal con razon, aaaaa, soy fan de campa        
        StartCoroutine(UpdateVariableAfterDelay());
        if (theRB == null)
        {
            theRB = GetComponent<Rigidbody>();
        }
        transform.position = new Vector3(783, -1080, -334);
        theRB.isKinematic = true;
        theRB.transform.position = new Vector3(783, -1080, -334);
        theRB.isKinematic = false;
        theRB.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.canMove == true)
        {
            theRB.useGravity = true;
            speedInput = 0f;
            if (Input.GetAxis("WS") > 0)
            {
                if (GameManager.Instance.masVelocidad2 == true)
                {
                    if (Input.GetKey(KeyCode.P))
                    {
                        powerUpActivado2 = true;
                        powerUpActivadoFin2 = Time.time + powerUpSpeedDuracion2;
                    }
                    else
                    {
                        speedInput = Input.GetAxis("WS") * aceleracion * 1000f;
                    }
                     
                    if (powerUpActivado2 == true)
                    {
                        speedInput = Input.GetAxis("WS") * aceleracion * 1500f;
                        Invoke("powerUp", desapareceTiempo);
                        if (Time.time > powerUpActivadoFin2)
                        {
                            powerUpActivado2 = false;
                        }
                    }
                }
                else
                {
                    speedInput = Input.GetAxis("WS") * aceleracion * 1000f;
                }
                
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

            ruedaAdelanteDerecha.localRotation = Quaternion.Euler(ruedaAdelanteDerecha.localRotation.eulerAngles.x, turnInput * maxGiroRueda, ruedaAdelanteDerecha.localRotation.eulerAngles.z);
            ruedaAdelanteIzquierda.localRotation = Quaternion.Euler(ruedaAdelanteIzquierda.localRotation.eulerAngles.x, turnInput * maxGiroRueda, ruedaAdelanteIzquierda.rotation.eulerAngles.z);
            transform.position = theRB.transform.position;

        }
        

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
    private IEnumerator UpdateVariableAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        cuentaRegresiva = 3f;
        GameManager.Instance.canMove = true;

    }
    void powerUp()
    {
        GameManager.Instance.masVelocidad2 = false;
    }
}
