using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCollector : MonoBehaviour
{
    public bool active;
    public bool collected;
    // Start is called before the first frame update
    void Start()
    {
        active = true;
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!active) return;
        var mov = other.GetComponent<Moveable>();
        if (mov != null && mov.ID=="star" && mov.active) _consumeStart(mov);
    }
    
    void _consumeStart(Moveable obj)
    {
        obj.transform.position = transform.position;
        obj.active = false;
        active = false;
        collected = true;
    }
    
}
