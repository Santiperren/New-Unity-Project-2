using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    public Rigidbody theRB1;
    public float aceleracion = 17f, reversa = 6f, maxSpeed = 3200f, turnStrenght = 150f, gravityForce = 10f, dragOnGround1;   
   
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
    public bool power1Act = false;
    public float power1Dur = 3f;
    private float power1ActFin;
    public bool power3Act = false;
    public float power3Dur = 5f;
    private float power3ActFin;
    public bool power2Act = false;
    public float power2Dur = 3f;
    private float power2ActFin;
    public Image imagen;
    public GameObject imagenTinta;
    public GameObject power1;
    public GameObject power2;
    public GameObject power3;
    public GameObject noDoblaM;
    int i = 0;
    public int db = 1;
    public bool noRepite = false;
    public Camera camaraNB;
    public Camera camara2B;
    public Camera camaraTibuB;


    // Start is called before the first frame update
    void Start()
    {
        theRB1.transform.parent = null;// AAAAAAAAAAAAAAAAAAAAAAAAAAAA mal        
        StartCoroutine(UpdateVariableAfterDelay());
        if (theRB1 == null)
        {
            theRB1 = GetComponent<Rigidbody>();
        }
        transform.position = new Vector3(820, -1075, -332);
        theRB1.isKinematic = true;
        theRB1.transform.position = new Vector3(820, -1075, -334);
        theRB1.isKinematic = false;
        theRB1.useGravity = false;
        camaraNB.enabled = true;
        camara2B.enabled = false;
        camaraTibuB.enabled = false;
        GameManager.Instance.noDobla2B = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (noRepite == false)
        {
            if (GameManager.Instance.noDobla1B == true)
            {
                noDoblaM.SetActive(true);
                Invoke("noDobla", 0.6f);
                noRepite = true;
                Invoke("repite", 5f);
            }
        }

        if (Input.GetButtonDown("LB"))
        {
            i++;

            cambiarCamaras();
        }

        if (GameManager.Instance.mancha1B == true)
        {
            StartCoroutine(MostrarYDesaparecer());
        }
        if (GameManager.Instance.mancha1 == true)
        {
            power3.SetActive(true);
            if (Input.GetButtonDown("A"))
            {
                soundmanagerscript.Instance.PlaySound(soundmanagerscript.Instance.mancha);
                GameManager.Instance.mancha2B = true;
                power3Act = true;
                power3ActFin = Time.time + power3Dur;
                GameManager.Instance.mancha1 = false;
                power3.SetActive(false);
            }
        }
        
        if (GameManager.Instance.noDobla1 == true)
        {
            power2.SetActive(true);
            if (Input.GetButtonDown("A"))
            {
                GameManager.Instance.noDobla2B = true;
                power2Act = true;
                power2ActFin = Time.time + power2Dur;
                GameManager.Instance.noDobla1 = false;
                power2.SetActive(false);
            }
            if (power2Act == true)
            {
                Invoke("powerUp2", power2Dur);
            }
        }
        if (GameManager.Instance.rotate01 == true)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            GameManager.Instance.rotate01 = false;
        }
        if (GameManager.Instance.menosDrag1 == true)
        {
            StartCoroutine(desactivarDrag());
        }
        else
        {
            dragOnGround1 = 3f;
        }
        if (GameManager.Instance.canMove == true)
        {
            theRB1.useGravity = true;
            speedInput = 0f;
            if (GameManager.Instance.masVelocidad1 == true)
            {
                if (db == 1)
                {
                    power1.SetActive(true);
                }
                else
                {
                    power1.SetActive(false);
                }
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                if (GameManager.Instance.masVelocidad1 == true)
                {
                    if (Input.GetButtonDown("A"))
                    {

                        powerUpActivado = true;
                        powerUpActivadoFin = Time.time + powerUpSpeedDuracion;
                        db = 2;
                    }
                    else
                    {
                        speedInput = Input.GetAxis("Vertical") * aceleracion * 1000f;
                    }
                    if (powerUpActivado == true)
                    {
                        speedInput = Input.GetAxis("Vertical") * aceleracion * 1500f;
                        if (Time.time > powerUpActivadoFin)
                        {
                            powerUpActivado = false;
                            Invoke("powerUp", 0.1f);
                        }
                    }
                }
                else
                {
                    speedInput = Input.GetAxis("Vertical") * aceleracion * 1000f;
                }

            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                speedInput = Input.GetAxis("Vertical") * reversa * 1000f;
            }
            else if (Input.GetAxis("Vertical") == 0)
            {
                speedInput = Input.GetAxis("Vertical") * aceleracion * 0f;
            }
            turnInput = Input.GetAxis("Horizontal");
            if (alPiso)
            {
                
                if (GameManager.Instance.noDobla1B == false)
                {                    
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
                }

            }


            ruedaAdelanteDerecha.localRotation = Quaternion.Euler(0, -turnInput * maxGiroRueda, 0);
            ruedaAdelanteIzquierda.localRotation = Quaternion.Euler(0, -turnInput * maxGiroRueda, 0);
            transform.position = theRB1.transform.position;

            // if (Input.GetKey(KeyCode.O))
            //(Input.GetButton("Fire1"))
            if (Input.GetButtonDown("B"))
            {
                if (GameManager.Instance.checkRespawn == 0)
                {
                    transform.position = new Vector3(783, -1080, -334);
                    theRB1.isKinematic = true;
                    theRB1.transform.position = new Vector3(783, -1080, -334);
                    theRB1.isKinematic = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
                }
                if (GameManager.Instance.checkRespawn == 1)
                {
                    transform.position = new Vector3(355, -1084, -484);
                    theRB1.isKinematic = true;
                    theRB1.transform.position = new Vector3(355, -1084, -484);
                    theRB1.isKinematic = false;
                    theRB1.useGravity = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
                }
                else if (GameManager.Instance.checkRespawn == 2)
                {
                    transform.position = new Vector3(317, -1084, -185);
                    theRB1.isKinematic = true;
                    theRB1.transform.position = new Vector3(317, -1084, -185);
                    theRB1.isKinematic = false;
                    theRB1.useGravity = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
                }
                else if (GameManager.Instance.checkRespawn == 3)
                {
                    transform.position = new Vector3(393, -1084, -45);
                    theRB1.isKinematic = true;
                    theRB1.transform.position = new Vector3(393, -1084, -45);
                    theRB1.isKinematic = false;
                    theRB1.useGravity = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y,0);
                }
                else if (GameManager.Instance.checkRespawn == 4)
                {
                    transform.position = new Vector3(783, -1080, -334);
                    theRB1.isKinematic = true;
                    theRB1.transform.position = new Vector3(783, -1080, -334);
                    theRB1.isKinematic = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, 0);
                }
            }
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
            theRB1.drag = dragOnGround1;
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

    private IEnumerator desactivarDrag()
    {

        dragOnGround1 = 1f;
        yield return new WaitForSeconds(3f);
        cuentaRegresiva = 3f;
        GameManager.Instance.menosDrag1 = false;
        dragOnGround1 = 3f;
    }
    private IEnumerator MostrarYDesaparecer()
    {

        //imagen.enabled = true;
        imagenTinta.SetActive(true);
       
        yield return new WaitForSeconds(5f);        
        imagenTinta.SetActive(false);
        GameManager.Instance.mancha1B = false;
        //imagen.enabled = false;
    }

    void powerUp()
      {

        GameManager.Instance.masVelocidad1 = false;
        power1.SetActive(false);
        db = 1;
      }
    void powerUp2()
    {
        power2Act = false;
        GameManager.Instance.noDobla2B = false;
    }
    void noDobla()
    {
        noDoblaM.SetActive(false);
    }
    void repite()
    {
        noRepite = false;
    }
    void cambiarCamaras()
    {
        if (i == 1)
        {
            camaraNB.enabled = false;
            camaraTibuB.enabled = false;
            camara2B.enabled = true;

        }
        else if (i == 2)
        {
            camaraNB.enabled = false;
            camaraTibuB.enabled = true;
            camara2B.enabled = false;
        }
        else if (i == 3)
        {
            camaraNB.enabled = true;
            camaraTibuB.enabled = false;
            camara2B.enabled = false;
            i = 0;
        }
    }

}
