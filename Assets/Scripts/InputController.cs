using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _mouseState;
    private GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;
    public Vector2 xLimit=new Vector2(0,100);
    public Vector2 zLimit=new Vector2(0,100);
    public GenerateButton GenerateButton;
    public AudioSource TakeSound;
    public AudioSource DropSound;
    private bool hasObj = false;

    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown (0)) {
            RaycastHit hitInfo;
            target = GetClickedObject (out hitInfo);
            if (target != null)
            {
                var obj = target.GetComponent<Moveable>();
                if ( obj!=null)
                {
                    var mov=obj;
                    if (mov.active)
                    {
                        mov.Use();
                        _mouseState = true;
                        screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
                        offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                        TakeSound.Play();
                        hasObj = true;
                    }
                }
                if ( target.GetComponent<GenerateButtonView>()!=null)
                {
                    target.GetComponent<GenerateButtonView>().Click();
                }
            }
        }
        if (Input.GetMouseButtonUp (0)) {
            _mouseState = false;
            if (hasObj)
            {
                hasObj = false;            
                DropSound.Play();
            }
            if (target.GetComponent<Rigidbody>()!=null)
                target.GetComponent<Rigidbody>().velocity = Vector3.down*1f;
        }
        if (_mouseState) {
            var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
            var x = curPosition.x;
            var z = curPosition.z;
            if (curPosition.x < xLimit.x) x = xLimit.x;
            if (curPosition.x > xLimit.y) x = xLimit.y;
            if (curPosition.z < zLimit.x) z = zLimit.x;
            if (curPosition.z > zLimit.y) z = zLimit.y;
            target.transform.position = new Vector3(x, 2, z);

        }
    }


    GameObject GetClickedObject (out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            target = hit.collider.gameObject;
        }
        return target;
    }

    public void DropObj()
    {
        _mouseState = false;
        if (hasObj)
        {
            hasObj = false;            
            DropSound.Play();
        }
        if (target!=null && target.GetComponent<Rigidbody>()!=null)
            target.GetComponent<Rigidbody>().velocity = Vector3.down*2f;
    }
}
