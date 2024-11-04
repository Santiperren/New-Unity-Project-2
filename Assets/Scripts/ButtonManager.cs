using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject autoAmarillo;
    public GameObject autoRojo;
    public GameObject autoVioleta;
    public GameObject autoRosa;
    public GameObject autoCeleste;
    public GameObject autoX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickButton(string sceneToLoad)
    {
        GameManager.Instance.ChangeScene(sceneToLoad);
    }
    public void OnClickButton1()
    {
        Debug.Log("funciono");
        autoRojo.SetActive(false);
        autoVioleta.SetActive(false);
        autoRosa.SetActive(false);
        autoCeleste.SetActive(false);
        autoX.SetActive(false);
        autoAmarillo.SetActive(true);
        Debug.Log("A");
        GameManager.Instance.autoDosSkin = 0;
    }
    public void OnClickButton2()
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
    public void OnClickButton3()
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
    public void OnClickButton6()
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
    public void OnClickButton5()
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
    public void OnClickButton4()
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
