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
    public float checkPointA = 0;
    public float checkPointB = 0;
    public float checkPointC = 0;
    public string autoUno;
    public string autoDos;
    public bool canMove = false;
    public bool masVelocidad1 = false;
    public bool masVelocidad2 = false;
    public bool afueraPista = false;
    

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
            ChangeScene("Juego");
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

