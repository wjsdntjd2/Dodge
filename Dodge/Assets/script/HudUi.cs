using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudUi : MonoBehaviour
{
    public GameObject StartMenu = null;
    public GameObject ResultGame = null;
    [HideInInspector] public Text CountText = null;
    [HideInInspector] public bool OnStart;
    int Count;

    public Text StopWatch;

    public bool GameStart;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Count = 0;
        GameStart = false;
        StopWatch.text = string.Format("{0:00}:{1:00}", Mng.Ins.Gameinfo.M, Mng.Ins.Gameinfo.S);
    }


    IEnumerator StartTime()
    {
        while (Count < 5)
        {
            Count++;
            Debug.Log(Count);
            if (Count <= 3)
            {
                CountText.text = Count.ToString();
            }
            else if (Count == 4)
            {
                CountText.text = "Start";
            }
            else if (Count == 5)
            {
                CountText.gameObject.SetActive(false);
                Mng.Ins.GameScene.Battle1.SetGame();
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void SetReadyState()
    {
        StartCoroutine(StartTime());
    }

    void Update()
    {   
        if (GameStart)
        {
            Mng.Ins.OnUpdate(0);    
            StopWatch.text = string.Format("{0:00}:{1:00}", Mng.Ins.Gameinfo.M, Mng.Ins.Gameinfo.S);
        }
    }
}
