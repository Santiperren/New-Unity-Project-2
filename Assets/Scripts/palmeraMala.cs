using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palmeraMala : MonoBehaviour
{
    private Animator mAnimator;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if (GameManager.Instance.palmeraMala == true)
            {
                mAnimator.SetTrigger("trCae");
                GameManager.Instance.palmeraMala = false;
                Invoke ("colliders",0.4f);
            }
        }
        
    }
    void colliders()
    {
        obj1.SetActive(true);
        obj2.SetActive(true);
        obj3.SetActive(true);
        obj4.SetActive(true);
        obj5.SetActive(true);
    }
    
}
