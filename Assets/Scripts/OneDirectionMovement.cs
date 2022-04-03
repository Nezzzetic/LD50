using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneDirectionMovement : MonoBehaviour
{
    
    public Vector3 Direction;
    public Vector3 LimitMin;
    public Vector3 LimitMax;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (_inLimit())
        _updatePosition();
    }

    void _updatePosition()
    {
        transform.position += Direction * Speed*Time.deltaTime;
    }
    
    bool  _inLimit()
    {
        return transform.position.x > LimitMin.x &&
               transform.position.y > LimitMin.y &&
               transform.position.z > LimitMin.z &&
               transform.position.x < LimitMax.x &&
               transform.position.y < LimitMax.y &&
               transform.position.z < LimitMax.z;
    }
}
