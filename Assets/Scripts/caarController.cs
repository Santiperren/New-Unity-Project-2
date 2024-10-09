using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class caarController : MonoBehaviour
{
    public Rigidbody theRB;
    public float aceleracion = 17f, reversa = 6f, maxSpeed = 3200f, turnStrenght = 200f, gravityForce = 10f, dragOnGround2;
    
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
    public Transform check1; 
    public Transform check2; 
    public Transform check3; 
    public Transform autoDos;
    public bool power2Act = false;
    public float power2Dur = 3f;
    private float power2ActFin;
    public bool power3Act = false;
    public float power3Dur = 5f;
    private float power3ActFin;
    public Image imagen;
    public Text vueltas;
    public GameObject imagenTinta;    
    public Camera camaraN;
    public Camera camara2;
    public Camera camaraTibu;
    public GameObject power1;
    public GameObject power2;
    public GameObject power3;
    int i = 0;
    public GameObject planecollider;
   
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
        camaraN.enabled = true;
        camara2.enabled = false;
        camaraTibu.enabled = false;

    }

    // Update is called once per frame
    void Update()

    {
      
            if (Input.GetKeyDown(KeyCode.C))
            {
                i++;

                cambiarCamaras();
            }
  
        if(GameManager.Instance.mancha2B == true)
        {
            StartCoroutine(MostrarYDesaparecer());
            StartCoroutine(MostrarYDesaparecer());
        }
        if (GameManager.Instance.mancha2 == true)
        {
            power3.SetActive(true);
            if (Input.GetKey(KeyCode.P))
            {
                soundmanagerscript.Instance.PlaySound(soundmanagerscript.Instance.mancha);
                GameManager.Instance.mancha1B = true;

                power3Act = true;
                power3ActFin = Time.time + power3Dur;
                GameManager.Instance.mancha2 = false;
                power3.SetActive(false);
            }
        }
        if (GameManager.Instance.noDobla2 == true)
        {
            power2.SetActive(true);
            if (Input.GetKey(KeyCode.P))
            {
                GameManager.Instance.noDobla1B = true;
                power2Act = true;
                power2ActFin = Time.time + power2Dur;
                GameManager.Instance.noDobla2 = false;
                power2.SetActive(false);
            }
            if (power2Act == true)
            {
                Invoke("powerUp2", power2Dur);
            }
        }
        if (GameManager.Instance.rotate02 == true)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            GameManager.Instance.rotate02 = false;
        }
        if (GameManager.Instance.menosDrag2 == true)
        {            
            StartCoroutine(desactivarDrag2());
        }
        else
        {
            dragOnGround2 = 3f;
        }
        
        if (GameManager.Instance.canMove == true)
        {
            theRB.useGravity = true;
            speedInput = 0f;
            if (GameManager.Instance.masVelocidad2 == true)
            {
                power1.SetActive(true);
            }

            if (Input.GetAxis("Vertical2") < 0)
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
                        speedInput = Input.GetAxis("Vertical2") * aceleracion * 1000f;
                    }
                     
                    if (powerUpActivado2 == true)
                    {
                        speedInput = Input.GetAxis("Vertical2") * aceleracion * 1500f;                        
                        if (Time.time > powerUpActivadoFin2)
                        {
                            powerUpActivado2 = false;
                            Invoke("powerUp",0.1f);
                        }
                    }
                }
                else
                {
                    speedInput = Input.GetAxis("Vertical2") * aceleracion * 1000f;
                }
                
            }
            else if (Input.GetAxis("Vertical2") > 0)
            {
                speedInput = Input.GetAxis("Vertical2") * reversa * 1000f;
            }
            
            turnInput = Input.GetAxis("Horizontal2");
            if (alPiso)
            {
                if (GameManager.Instance.noDobla2B== false)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrenght * Time.deltaTime * Input.GetAxis("Vertical2"), 0f));
                }
                


            }

            if (Input.GetKey(KeyCode.X))
            {
                if (GameManager.Instance.checkRespawn2 == 0)
                {
                    transform.position = new Vector3(783, -1080, -334);
                    theRB.isKinematic = true;
                    theRB.transform.position = new Vector3(783, -1080, -334);
                    theRB.isKinematic = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
                }
                if (GameManager.Instance.checkRespawn2 == 1)
                {
                    transform.position = new Vector3(355, -1084, -484);
                    theRB.isKinematic = true;
                    theRB.transform.position = new Vector3(355, -1084, -484);
                    theRB.isKinematic = false;
                    theRB.useGravity = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
                }
                else if (GameManager.Instance.checkRespawn2 == 2)
                {
                    transform.position = new Vector3(565, -1084, -236);
                    theRB.isKinematic = true;
                    theRB.transform.position = new Vector3(565, -1084, -236);
                    theRB.isKinematic = false;
                    theRB.useGravity = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
                }
                else if (GameManager.Instance.checkRespawn2 == 3)
                {
                    transform.position = new Vector3(393, -1084, -45);
                    theRB.isKinematic = true;
                    theRB.transform.position = new Vector3(393, -1084, -45);
                    theRB.isKinematic = false;
                    theRB.useGravity = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
                }
                else if (GameManager.Instance.checkRespawn2 == 4)
                {
                    transform.position = new Vector3(783, -1080, -334);
                    theRB.isKinematic = true;
                    theRB.transform.position = new Vector3(783, -1080, -334);
                    theRB.isKinematic = false;
                    Vector3 currentRotation = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
                }
               


            }

            ruedaAdelanteDerecha.localRotation = Quaternion.Euler(0, -turnInput * maxGiroRueda, 0);
            ruedaAdelanteIzquierda.localRotation = Quaternion.Euler(0, -turnInput * maxGiroRueda, 0);
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
            gravityForce = 10f;
            theRB.drag = dragOnGround2;
            if (Mathf.Abs(speedInput) > 0)
            {
                theRB.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;
            }
        }
        else
        {
            theRB.drag = 0.1f;
            gravityForce = 20f;
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
    private IEnumerator MostrarYDesaparecer()
    {
        //imagen.enabled = true;
        imagenTinta.SetActive(true);
        yield return new WaitForSeconds(5f);        
        imagenTinta.SetActive(false);
        GameManager.Instance.mancha2B = false;
        //imagen.enabled = false;
    }
    private IEnumerator desactivarDrag2()
    {

        dragOnGround2 = 1f;
        yield return new WaitForSeconds(3f);
        cuentaRegresiva = 3f;
        GameManager.Instance.menosDrag2 = false;
        dragOnGround2 = 3f;

    }
    void powerUp()
    {

        GameManager.Instance.masVelocidad2 = false;
        power1.SetActive(false);
    }
    void powerUp2()
    {
        GameManager.Instance.noDobla1B = false;
    }
    void cambiarCamaras()
    {
        if(i == 1)
        {
            camaraN.enabled = false;
            camaraTibu.enabled = false;
            camara2.enabled = true;

        }
        else if (i == 2)
        {
            camaraN.enabled = false;
            camaraTibu.enabled = true;
            camara2.enabled = false;
        }
        else if(i == 3)
        {
            camaraN.enabled = true;
            camaraTibu.enabled = false;
            camara2.enabled = false;
            i = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plano"))
        {
            if (GameManager.Instance.checkRespawn2 == 0)
            {
                transform.position = new Vector3(783, -1080, -334);
                theRB.isKinematic = true;
                theRB.transform.position = new Vector3(783, -1080, -334);
                theRB.isKinematic = false;
                Vector3 currentRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            }
            if (GameManager.Instance.checkRespawn2 == 1)
            {
                transform.position = new Vector3(355, -1084, -484);
                theRB.isKinematic = true;
                theRB.transform.position = new Vector3(355, -1084, -484);
                theRB.isKinematic = false;
                theRB.useGravity = false;
                Vector3 currentRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            }
            else if (GameManager.Instance.checkRespawn2 == 2)
            {
                transform.position = new Vector3(565, -1084, -236);
                theRB.isKinematic = true;
                theRB.transform.position = new Vector3(565, -1084, -236);
                theRB.isKinematic = false;
                theRB.useGravity = false;
                Vector3 currentRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            }
            else if (GameManager.Instance.checkRespawn2 == 3)
            {
                transform.position = new Vector3(393, -1084, -45);
                theRB.isKinematic = true;
                theRB.transform.position = new Vector3(393, -1084, -45);
                theRB.isKinematic = false;
                theRB.useGravity = false;
                Vector3 currentRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            }
            else if (GameManager.Instance.checkRespawn2 == 4)
            {
                transform.position = new Vector3(783, -1080, -334);
                theRB.isKinematic = true;
                theRB.transform.position = new Vector3(783, -1080, -334);
                theRB.isKinematic = false;
                Vector3 currentRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(0, currentRotation.y, currentRotation.z);
            }
        }
    }

}
