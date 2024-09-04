using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    public Rigidbody theRB1;
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
    public AudioClip soundSpace;
    public float desapareceTiempo = 5f;
    private float cuentaRegresiva;
    public bool powerUpActivado = false;
    public float powerUpSpeedDuracion = 5f;
    private float powerUpActivadoFin;
    


    // Start is called before the first frame update
    void Start()
    {
        theRB1.transform.parent = null;// AAAAAAAAAAAAAAAAAAAAAAAAAAAA mal        
        StartCoroutine(UpdateVariableAfterDelay());
        if (theRB1 == null)
        {
            theRB1 = GetComponent<Rigidbody>();
        }
        transform.position = new Vector3(820, -1080, -334);
        theRB1.isKinematic = true;
        theRB1.transform.position = new Vector3(820, -1080, -334);
        theRB1.isKinematic = false;
        theRB1.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.canMove == true)
        {
            theRB1.useGravity = true;
            speedInput = 0f;
            if (Input.GetAxis("Vertical") > 0)
            {
                if(GameManager.Instance.masVelocidad1 == true)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        powerUpActivado = true;
                        powerUpActivadoFin = Time.time + powerUpSpeedDuracion;
                    }
                    else
                    {
                        speedInput = Input.GetAxis("Vertical") * aceleracion * 1000f;
                    }
                    if (powerUpActivado == true)
                    {
                        speedInput = Input.GetAxis("Vertical") * aceleracion * 1500f;
                        Invoke("powerUp", desapareceTiempo);
                        if (Time.time > powerUpActivadoFin)
                        {
                            powerUpActivado = false;
                        }
                    }
                }
                else
                {
                    speedInput = Input.GetAxis("Vertical") * aceleracion * 1000f;
                }
                
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                speedInput = Input.GetAxis("Vertical") * reversa * 1000f;
            }
            turnInput = Input.GetAxis("Horizontal");
            if (alPiso)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
            }

            ruedaAdelanteDerecha.localRotation = Quaternion.Euler(ruedaAdelanteDerecha.localRotation.eulerAngles.x, (turnInput * maxGiroRueda) - 180, ruedaAdelanteDerecha.rotation.eulerAngles.z);
            ruedaAdelanteIzquierda.localRotation = Quaternion.Euler(ruedaAdelanteIzquierda.localRotation.eulerAngles.x, turnInput * maxGiroRueda, ruedaAdelanteIzquierda.rotation.eulerAngles.z);
            transform.position = theRB1.transform.position;
        }
            
       
    }
    private void FixedUpdate()
    {
        // theRB.AddForce(transform.forward * aceleracion * 1000f);
       alPiso = false;
       RaycastHit hit;
       if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groungRayLenght, estaEnElPiso))
        {
            alPiso = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        emissionRate = 0;
        if (alPiso)
        {
            gravityForce = 10f;
            theRB1.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                theRB1.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;
            }
        }
        else
        {
            theRB1.drag = 0.5f;
            gravityForce = 15f;
            theRB1.AddForce(Vector3.up * -gravityForce * 100f);
        }
        foreach(ParticleSystem part in dustTrial)
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
        GameManager.Instance.masVelocidad1 = false;
    }
}
