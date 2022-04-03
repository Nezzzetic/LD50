using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    //В воздухе, на земле, на генераторе, в лаве, уничтожена лавой, захвачена
    public bool active;
    public bool used;
    public bool collected;
    public string ID;
    public GenerateButton GenerateButton;
    public Action FirstUsed=delegate {  };
    public Rigidbody rb;

    public void OnLavaAction()
    {
        active = false;
        //rb.useGravity = false;
        //rb.isKinematic = true;
    }
    
    
    public void OnLavaFinishAction()
    {
        gameObject.SetActive(false);
    }
    
    public void Use()
    {
        if (!used)
        {
            used = true;
            FirstUsed();
        }
    } 
    
    public void OnCollectorAction()
    {
        transform.position = transform.position;
        active = false;
        collected = true;
        rb.useGravity = false;
        rb.isKinematic = true;
    } 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
