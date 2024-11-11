using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float checkPoint1 = 0;
    public float checkPoint2 = 0;
    public float checkPoint3 = 0;
    public float checkPoint4 = 0;
    public float checkPointA = 0;
    public float checkPointB = 0;
    public float checkPointC = 0;
    public float checkPointD = 0;
    public int checkRespawn = 0;
    public int checkRespawn2 = 0;
    public bool menosDrag1 = false;
    public bool menosDrag2 = false;
    public bool rotate01 = false;
    public bool rotate02 = false;
    public string autoUno = "autoUno";
    public string autoDos = "autoDos";
    public bool canMove = false;
    public bool noDobla1 = false;
    public bool noDobla2 = false;
    public bool noDobla1B = false;
    public bool noDobla2B = false;
    public bool masVelocidad1 = false;
    public bool masVelocidad2 = false;
    public bool mancha1 = false;
    public bool mancha2 = false;
    public bool mancha2B = false;
    public bool mancha1B = false;
    public bool afueraPista = false;
    public bool honguitoMalo = false;
    public bool palmeraMala = false;
    public bool j1Texture = false;
    public bool j2Texture = false;
    public int autoUnoSkin;
    public int autoDosSkin;
    public bool delay = true;
    public GameObject masVelocidadUno;
    public GameObject masVelocidaDos;
   


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            canMove = false;
            noDobla1 = false;
            noDobla2 = false;
            noDobla1B = false;
            noDobla2B = false;
            masVelocidad1 = false;
            masVelocidad2 = false;
            mancha1B = false;
            mancha2B = false;
            mancha1 = false;
            mancha2 = false;
            ChangeScene("Juego");
            delay = true;
            
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeScene("Menu");
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnPlayButtonPressed()
    {
        ChangeScene("SelectPlayer");
    }

    public void OnMenuButtonPressed()
    {
        ChangeScene("Menu");
    }

    public void OnSelectPlayerButtonPressed()
    {
        ChangeScene("menu2");
    }

    public void Onmenu2ButtonPressed()
    {
        ChangeScene("Juego");
    }
}

