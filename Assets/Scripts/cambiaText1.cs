using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiaText1 : MonoBehaviour
{
    
    public int[] textures;
    public int autoSkin;
    public GameObject autoAmarillo;
    public GameObject autoRojo;
    public GameObject autoVioleta;
    public GameObject autoRosa;
    public GameObject autoCeleste;
    public GameObject autoX;

    private Renderer targetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTexture(int index)
    {
        
        if (index >= 0 && index < textures.Length)
        {
            autoSkin = textures[index];
            Debug.Log("funcionoaaaaaaaaaaaaaaaaa");
        }

        if ( autoSkin == 0)
        {
            autoRojo.SetActive(false);
            autoVioleta.SetActive(false);
            autoRosa.SetActive(false);
            autoCeleste.SetActive(false);
            autoX.SetActive(false);
            autoAmarillo.SetActive(true);
            Debug.Log("A");
            GameManager.Instance.autoDosSkin = 0;
        }
        else if (autoSkin == 1)
        {
            autoRojo.SetActive(true);
            autoVioleta.SetActive(false);
            autoRosa.SetActive(false);
            autoCeleste.SetActive(false);
            autoX.SetActive(false);
            autoAmarillo.SetActive(false);
            Debug.Log("R");
            GameManager.Instance.autoDosSkin = 1;
        }
        else if (autoSkin == 2)
        {
            autoRojo.SetActive(false);
            autoVioleta.SetActive(true);
            autoRosa.SetActive(false);
            autoCeleste.SetActive(false);
            autoX.SetActive(false);
            autoAmarillo.SetActive(false);
            Debug.Log("V");
            GameManager.Instance.autoDosSkin = 2;
        }
        else if (autoSkin == 3)
        {
            autoRojo.SetActive(false);
            autoVioleta.SetActive(false);
            autoRosa.SetActive(true);
            autoCeleste.SetActive(false);
            autoX.SetActive(false);
            autoAmarillo.SetActive(false);
            Debug.Log("Ros");
            GameManager.Instance.autoDosSkin = 3;
        }
        else if (autoSkin == 4)
        {
            autoRojo.SetActive(false);
            autoVioleta.SetActive(false);
            autoRosa.SetActive(false);
            autoCeleste.SetActive(true);
            autoX.SetActive(false);
            autoAmarillo.SetActive(false);
            Debug.Log("C");
            GameManager.Instance.autoDosSkin = 4;
        }
        else if (autoSkin == 5)
        {
            autoRojo.SetActive(false);
            autoVioleta.SetActive(false);
            autoRosa.SetActive(false);
            autoCeleste.SetActive(false);
            autoX.SetActive(true);
            autoAmarillo.SetActive(false);
            Debug.Log("AZ");
            GameManager.Instance.autoDosSkin = 5;
        }
    }
}
