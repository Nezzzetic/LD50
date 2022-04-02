using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        var mov = other.GetComponent<Moveable>();
        if (mov != null && mov.ID=="star") _consumeStart(mov);
    }
    
    void _consumeStart(Moveable obj)
    {
        obj.active = false;
    }
    
}
