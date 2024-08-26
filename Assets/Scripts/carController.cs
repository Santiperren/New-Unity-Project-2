using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    public Rigidbody theRB;
    public float aceleracion = 20f, reversa = 6f, maxSpeed = 3200f, turnStrenght = 180f, gravityForce = 10f, dragOnGround = 3f;

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
    private float cuentaRegresiva;
    private bool canMove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;// AAAAAAAAAAAAAAAAAAAAAAAAAAAA mal        
        StartCoroutine(UpdateVariableAfterDelay());
        if (theRB == null)
        {
            theRB = GetComponent<Rigidbody>();
        }
        transform.position = new Vector3(820, -1082, -334);
        theRB.isKinematic = true;
        theRB.transform.position = new Vector3(820, -1082, -334);
        theRB.isKinematic = false;
        theRB.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            theRB.useGravity = true;
            speedInput = 0f;
            if (Input.GetAxis("Vertical") > 0)
            {
                speedInput = Input.GetAxis("Vertical") * aceleracion * 1000f;
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
            transform.position = theRB.transform.position;
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
        canMove = true;

    }
}
