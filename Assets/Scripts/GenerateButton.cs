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
    public GameObject ActiveGraphics2;
    public AudioSource ClickSound;
    public GameObject CreateFX;
    public GameObject CreateFX2;
    ParticleSystem.EmissionModule em;
    ParticleSystem.EmissionModule em2;
    
    // Start is called before the first frame update
    void Awake()
    {
        FigureGenerator.OnFigureTaken += RunTakeCD;
        active = true;
        FigureGenerator.CreateFigure();
        ParticleSystem ps = CreateFX.GetComponent<ParticleSystem>();
        ParticleSystem ps2 = CreateFX2.GetComponent<ParticleSystem>();
        em = ps.emission;
        em.enabled = false;
        em2 = ps2.emission;
        em2.enabled = false;
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
                ActiveGraphics2.SetActive(false);
                em.enabled = false;
                em2.enabled = false;
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
        ActiveGraphics2.SetActive(true);
        em2.enabled = true;
        
        create = true;
        FigureGenerator.DisableFigure();
        ClickSound.Play();
    }
    
    public void RunTakeCD()
    {
        timer = TakeCD;
        active = false;
        ActiveGraphics.SetActive(false);
        ActiveGraphics2.SetActive(true);
        takecd = true;
        em.enabled = true;
    }

}
