using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneDirectionMovement : MonoBehaviour
{
    
    public Vector3 Direction;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        _updatePosition();
    }

    void _updatePosition()
    {
        transform.position += Direction * Speed*Time.deltaTime;
    }
}
