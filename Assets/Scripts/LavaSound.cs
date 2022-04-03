using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSound : MonoBehaviour
{
    public Lava[] Lavas;

    public GameObject LavaFastSound;
    public GameObject LavaSlowSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool slow = true;
        for (int i = 0; i < Lavas.Length; i++)
        {
            if (!Lavas[i].Slow)
            {
                slow = false;
                break;
            }
        }
        LavaFastSound.SetActive(!slow);
        LavaSlowSound.SetActive(slow);
    }
}
