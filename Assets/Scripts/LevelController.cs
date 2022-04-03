using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int NextScene;
    public FigureCollector[] Collectors;
    public LoseTrigger LoseTrigger;
    public float EndTimer;
    public float StartTimer;
    public bool lost;
    public bool win;
    public GameObject LostStartScreen;
    public GameObject LostEndScreen;
    public GameObject WinStartScreen;
    public GameObject WinEndScreen;
    public Moveable[] BoxPrefab;
    public FigureGenerator FigureGenerator;
    // Start is called before the first frame update
    void Start()
    {
        FigureGenerator.CreateFigure();
    }
    
    void Awake()
    {
        FigureGenerator.BoxPrefab = BoxPrefab;
        StartTimer = 1;
        var lose = PlayerPrefs.GetInt("lose",0);
        if (lose==0) WinStartScreen.SetActive(true);
        else
            LostStartScreen.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_starsCollected() && !lost && !win)
        {
            EndTimer = 2;
            PlayerPrefs.SetInt("lose",0);
            WinEndScreen.SetActive(true);
            win = true;
        }
        
        if (_checkLose() && !lost && !win)
        {
            lost = true;
            EndTimer = 2;
            PlayerPrefs.SetInt("lose",1);
            LostEndScreen.SetActive(true);
        }
        
        if (EndTimer > 0)
        {
            EndTimer -= Time.deltaTime;
            if (EndTimer <= 0)
            {
                if (lost) Lose();
                else SceneManager.LoadScene(NextScene);
            }
        }
        
        if (StartTimer > 0)
        {
            StartTimer -= Time.deltaTime;
            if (StartTimer <= 0)
            {
                WinStartScreen.SetActive(false);
                LostStartScreen.SetActive(false);
            }
        }
    }

    bool _starsCollected()
    {
        foreach (var collector in Collectors)
        {
            if (!collector.collected) return false;
        }
        return true;
    }
    
    bool _checkLose()
    {
            if (!LoseTrigger.lost) return false;
        return true;
    }

    public void Lose()
    {
        SceneManager.LoadScene(NextScene-1);
    }
}
