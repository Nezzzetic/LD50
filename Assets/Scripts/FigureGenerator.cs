using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerator : MonoBehaviour
{
    public Moveable[] BoxPrefab;
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
        
    }

    public void CreateFigure()
    {
        var rndBox = Random.Range(0, BoxPrefab.Length-1);
        var box = Instantiate(BoxPrefab[rndBox], SpawnLoc.position, Quaternion.identity);
        if (box.ID!="star") {
            var rx = Random.Range(XScaleRange[0], XScaleRange[1]);
            var rz = Random.Range(ZScaleRange[0], ZScaleRange[1]);
            var rr = Random.Range(0, 360);
            box.transform.localScale=new Vector3(rx,1,rz);
            box.transform.localScale=new Vector3(rx,1,rz);
            box.transform.Rotate(new Vector3(0,rr,0));
        }
    }
    
    
}
