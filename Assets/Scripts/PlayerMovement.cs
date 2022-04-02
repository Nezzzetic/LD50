using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += transform.forward * Speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position -= transform.forward * Speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0,RotSpeed*Time.deltaTime,0));
        if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(new Vector3(0,-RotSpeed*Time.deltaTime,0));
    }
}
