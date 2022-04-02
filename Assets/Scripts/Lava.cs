using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float Speed;
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

    void OnTriggerEnter(Collider other)
    {
        IntersecCount++;
    }
    void OnTriggerExit(Collider other)
    {
        IntersecCount--;
    }
}
