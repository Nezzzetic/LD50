using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    
    public bool active;
    public bool used;
    public string ID;

    public void OnLavaAction()
    {
        active = false;
    }
    
    public void OnLavaFinishAction()
    {
        gameObject.SetActive(false);
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
