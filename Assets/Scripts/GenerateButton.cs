using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateButton : MonoBehaviour
{
    public float CreateCD;
    public float TakeCD;
    private bool create;
    private bool takecd;
    private float timer;
    private bool active;
    public FigureGenerator FigureGenerator;
    public GameObject ActiveGraphics;
    
    // Start is called before the first frame update
    void Awake()
    {
        FigureGenerator.OnFigureTaken += RunTakeCD;
        active = true;
        FigureGenerator.CreateFigure();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                active = true;
                ActiveGraphics.SetActive(true);
                if (create || takecd) {
                    FigureGenerator.CreateFigure();
                    create = false;
                    takecd = false;
                }
            }
        }
    }

    public void Click()
    {
        if (!active) return;
        active = false;
        timer = CreateCD;
        ActiveGraphics.SetActive(false);
        create = true;
        FigureGenerator.DisableFigure();
    }
    
    public void RunTakeCD()
    {
        timer = TakeCD;
        active = false;
        ActiveGraphics.SetActive(false);
        takecd = true;
    }

}
