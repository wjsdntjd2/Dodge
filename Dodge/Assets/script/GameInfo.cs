using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo 
{
    float Timer;
    public float S;
    public float M;

    public void Init()
    {
        Timer = 0;
        S = 0;
        M = 0;
    }

    // Update is called once per frame
    public void OnUpdate(float fElasedTime)
    {
        Timer += Time.deltaTime;
        S = (int)(Timer % 60);
        M = (int)(Timer / 60);
    }
}
