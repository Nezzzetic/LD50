using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateButton : MonoBehaviour
{
    public float CreateCD;
    public float TakeCD;
    private float timer;
    private bool active;
    public FigureGenerator FigureGenerator;
    public GameObject ActiveGraphics;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                ActiveGraphics.SetActive(false);
            }
        }
    }

    public void Click()
    {
        if (!active) return;
        FigureGenerator.CreateFigure();
        active = false;
        timer = CreateCD;
        ActiveGraphics.SetActive(true);
    }
    
    public void RunTakeCD()
    {
        timer = TakeCD;
        active = false;
        ActiveGraphics.SetActive(true);
    }

}
