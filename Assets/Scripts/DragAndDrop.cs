using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour
{  
    private bool _mouseState;
    private GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;

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
            if (target != null && target.GetComponent<Moveable>()!=null) {
                _mouseState = true;
                screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
        if (Input.GetMouseButtonUp (0)) {
            _mouseState = false;
        }
        if (_mouseState) {
            var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
            target.transform.position = new Vector3(curPosition.x,2,curPosition.z);;
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
}