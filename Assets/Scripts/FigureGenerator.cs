using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerator : MonoBehaviour
{
    public Transform BoxPrefab;
    public Transform SpawnLoc;
    public float[] XScaleRange = {0 ,0 };
    public float[] ZScaleRange = {0 ,0 };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp (0)) {
            RaycastHit hitInfo;
            var target = GetClickedObject (out hitInfo);
            Debug.Log(target.name);
            if (target != null && target==gameObject) {
                CreateFigure();
            }
        }
    }

    void CreateFigure()
    {
        var box = Instantiate(BoxPrefab, SpawnLoc.position, Quaternion.identity);
        var rx = Random.Range(XScaleRange[0], XScaleRange[1]);
        var rz = Random.Range(ZScaleRange[0], ZScaleRange[1]);
        var rr = Random.Range(0, 360);
        box.transform.localScale=new Vector3(rx,1,rz);
        box.transform.localScale=new Vector3(rx,1,rz);
        box.Rotate(new Vector3(0,rr,0));
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
