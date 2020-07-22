using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuDlg : MonoBehaviour
{
    public void Show(bool bShow)
    {
        gameObject.SetActive(bShow);
    }

    public void Init ()
    {

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

    public void OnClickStart()
    {
        CloseUI();
        Mng.Ins.GameScene.HudUi.StopWatch.gameObject.SetActive(true);
        Mng.Ins.GameScene.HudUi.CountText.gameObject.SetActive(true);
        Mng.Ins.GameScene.HudUi.OnStart = true;
        Mng.Ins.GameScene.Battle1.SetReady();
    }
}
