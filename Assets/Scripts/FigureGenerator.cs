using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FigureGenerator : MonoBehaviour
{
    public Moveable[] BoxPrefab;
    public Transform SpawnLoc;
    public float[] XScaleRange = {0 ,0 };
    public float[] ZScaleRange = {0 ,0 };
    private Moveable lastBox;
    public Action OnFigureTaken=delegate {  };
    
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
        var rndBox = UnityEngine.Random.Range(0, BoxPrefab.Length-1);
        lastBox = Instantiate(BoxPrefab[rndBox], SpawnLoc.position, Quaternion.identity);
        lastBox.FirstUsed += OnFigureTaken;
        if (lastBox.ID!="star") {
            var rx = UnityEngine.Random.Range(XScaleRange[0], XScaleRange[1]);
            var rz = UnityEngine.Random.Range(ZScaleRange[0], ZScaleRange[1]);
            var rr = UnityEngine.Random.Range(0, 360);
            lastBox.transform.localScale=new Vector3(rx,1,rz);
            lastBox.transform.localScale=new Vector3(rx,1,rz);
            lastBox.transform.Rotate(new Vector3(0,rr,0));
        }
        
    }

    public void DisableFigure()
    {
        if (lastBox!=null && !lastBox.used) lastBox.gameObject.SetActive(false);
    }
    
    
}
