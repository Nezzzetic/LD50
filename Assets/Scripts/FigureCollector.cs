using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureCollector : MonoBehaviour
{
    public bool active;
    public bool collected;
    public string ID;
    public GameObject View;
    public GameObject CollectFX;
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
        if (mov != null && mov.ID==ID && mov.active) _consumeStart(mov);
    }
    
    void _consumeStart(Moveable obj)
    {
        obj.OnCollectorAction();
        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.identity;
        active = false;
        collected = true;
        View.SetActive(false);
        CollectFX.SetActive(true);
    }
    
}
