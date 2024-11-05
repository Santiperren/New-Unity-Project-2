using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager2 : MonoBehaviour
{
    public GameObject autoAmarillo1;
    public GameObject autoRojo1;
    public GameObject autoVioleta1;
    public GameObject autoRosa1;
    public GameObject autoCeleste1;
    public GameObject autoX1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton1()
    {
        Debug.Log("funciono");
        autoRojo1.SetActive(false);
        autoVioleta1.SetActive(false);
        autoRosa1.SetActive(false);
        autoCeleste1.SetActive(false);
        autoX1.SetActive(false);
        autoAmarillo1.SetActive(true);
        Debug.Log("A");
        GameManager.Instance.autoUnoSkin = 0;
    }
    public void OnClickButton2()
    {
        autoRojo1.SetActive(true);
        autoVioleta1.SetActive(false);
        autoRosa1.SetActive(false);
        autoCeleste1.SetActive(false);
        autoX1.SetActive(false);
        autoAmarillo1.SetActive(false);
        Debug.Log("R");
        GameManager.Instance.autoUnoSkin = 1;
    }
    public void OnClickButton3()
    {
        autoRojo1.SetActive(false);
        autoVioleta1.SetActive(true);
        autoRosa1.SetActive(false);
        autoCeleste1.SetActive(false);
        autoX1.SetActive(false);
        autoAmarillo1.SetActive(false);
        Debug.Log("V");
        GameManager.Instance.autoUnoSkin = 2;
    }
    public void OnClickButton6()
    {
        autoRojo1.SetActive(false);
        autoVioleta1.SetActive(false);
        autoRosa1.SetActive(true);
        autoCeleste1.SetActive(false);
        autoX1.SetActive(false);
        autoAmarillo1.SetActive(false);
        Debug.Log("Ros");
        GameManager.Instance.autoUnoSkin = 3;
    }
    public void OnClickButton5()
    {
        autoRojo1.SetActive(false);
        autoVioleta1.SetActive(false);
        autoRosa1.SetActive(false);
        autoCeleste1.SetActive(true);
        autoX1.SetActive(false);
        autoAmarillo1.SetActive(false);
        Debug.Log("C");
        GameManager.Instance.autoUnoSkin = 4;
    }
    public void OnClickButton4()
    {
        autoRojo1.SetActive(false);
        autoVioleta1.SetActive(false);
        autoRosa1.SetActive(false);
        autoCeleste1.SetActive(false);
        autoX1.SetActive(true);
        autoAmarillo1.SetActive(false);
        Debug.Log("AZ");
        GameManager.Instance.autoUnoSkin = 5;
    }
}
