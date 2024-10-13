using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPU : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float bobbingSpeed = 2f;
    public float bobbingHeight = 1f;
    public float desapareceTiempo = 2f;
    

    private Vector3 startPosition;

    
    void Start()
    {
        startPosition = transform.position;
    }

    
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        float newY = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        transform.position = startPosition + new Vector3(0, newY, 0);
    }

    
    public void OnTriggerEnter(Collider other)
    {
       
        soundmanagerscript.Instance.PlaySound(soundmanagerscript.Instance.cajita);
        if (GameManager.Instance.masVelocidad1 == true || GameManager.Instance.masVelocidad2 == true || GameManager.Instance.noDobla1 == true || GameManager.Instance.noDobla2 == true || GameManager.Instance.mancha1 == true || GameManager.Instance.mancha2 == true)
        {

        }
        else
        {
            if (other.CompareTag(GameManager.Instance.autoUno))
            {
                int randomNumber = GetRandomNumber(1, 3);

                HandleRandomNumber(randomNumber);
            }
            else if (other.CompareTag(GameManager.Instance.autoDos))
            {
                int randomNumber2 = GetRandomNumber(1, 3);

                HandleRandomNumber2(randomNumber2);
            }
        }
        
        gameObject.SetActive(false);  
        

     
        Invoke("Reappear", desapareceTiempo);
    }

    void Reappear()
    {
        gameObject.SetActive(true);
    }

    
    int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
    int GetRandomNumber2(int min, int max)
    {
        return Random.Range(min, max + 1);
    }


    void HandleRandomNumber(int number)
    {
        switch (number)
        {
            case 1:

                GameManager.Instance.masVelocidad1 = true;
                Debug.Log("1");
                break;
            case 2:
                GameManager.Instance.noDobla1 = true;
                Debug.Log("2");
                break;
            case 3:
                GameManager.Instance.mancha1=true;
                Debug.Log("3");
                break;
        }
    }
    void HandleRandomNumber2(int number)
    {
        switch (number)
        {
            case 1:
                
                GameManager.Instance.masVelocidad2 = true;
                Debug.Log("1b");
                break;
            case 2:
                           
                GameManager.Instance.noDobla2 = true;
                Debug.Log("2b");
                break;
            case 3:
                GameManager.Instance.mancha2 = true;
                Debug.Log("3b");
                break;
        }
    }
}