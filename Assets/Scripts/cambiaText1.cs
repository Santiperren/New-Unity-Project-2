using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiaText1 : MonoBehaviour
{
    public GameObject targetObject;   
    public Texture[] textures;       

    private Renderer targetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTexture(int index)
    {
        
        if (targetRenderer != null && index >= 0 && index < textures.Length)
        {
            targetRenderer.material.mainTexture = textures[index];
        }
        else
        {
            Debug.LogWarning("Índice fuera de rango o renderer no asignado.");
        }
    }
}
