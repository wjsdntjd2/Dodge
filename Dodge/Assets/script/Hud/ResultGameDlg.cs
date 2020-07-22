using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameDlg : MonoBehaviour
{
    public Text Count;

    public void Show(bool bShow)
    {
        gameObject.SetActive(bShow);
    }

    public void OpenUI()
    {
        Show(true);
        Init();
    }

    public void CloseUI()
    {
        Show(false);
    }
   
    public void Init()
    {
        Count.text = string.Format("{0:00}:{1:00}", Mng.Ins.Gameinfo.M, Mng.Ins.Gameinfo.S);
    }

    public void OnClickRePlay()
    {
        CloseUI();
        Mng.Ins.GameScene.HudUi.StopWatch.gameObject.SetActive(true);
        Mng.Ins.GameScene.HudUi.CountText.gameObject.SetActive(true);
        Mng.Ins.GameScene.Battle1.SetReady();
    }

    public void OnClickMain()
    {
        CloseUI();
        Mng.Ins.GameScene.HudUi.StartMenu.GetComponent<StartMenuDlg>().OpenUI();
    }
}
