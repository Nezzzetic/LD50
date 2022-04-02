using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int NextScene;
    public FigureCollector[] Collectors;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_starsCollected())
        {
            SceneManager.LoadScene(NextScene);
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
}
