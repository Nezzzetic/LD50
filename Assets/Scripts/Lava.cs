using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float Speed => _getSpeed();
    public float DefaultSpeed;
    public float SlowSpeed;
    public Vector3 Direction;
    public int IntersecCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _updatePosition();
    }

    void _updatePosition()
    {
        transform.position += Direction * Speed*Time.deltaTime;
    }
    
    float _getSpeed()
    {
        if (IntersecCount > 0) return SlowSpeed;
        return DefaultSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        IntersecCount++;
    }
    void OnTriggerExit(Collider other)
    {
        IntersecCount--;
    }
}
