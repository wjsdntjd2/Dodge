using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameUi GameUi;
    public HudUi HudUi;
    public Transform BulletParent;
    [HideInInspector] public BattleFSM Battle1 = new BattleFSM();

    private void Awake()
    {
        Battle1.Init(Callback_ReadyState, Callback_GameState, Callback_WaveState, Callback_ResultState);
    }

    private void Update()
    {
        if (Battle1 != null)
        {
            Battle1.OnUpdate();
        }
    }

    void Callback_ReadyState()
    {
        HudUi.SetReadyState();
        GameUi.Player.Init();

        Bullet[] bullets = BulletParent.GetComponentsInChildren<Bullet>();
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject, 0.001f);
        }

        for (int i = 0; i < GameUi.Turret.Length; i++)
        {
            GameUi.Turret[i].Init();
        }
        Mng.Ins.Init();
        HudUi.Init();
    }

    void Callback_GameState()
    {
        for (int i = 0; i < GameUi.Turret.Length; i++)
        {
            GameUi.Turret[i].BulletShoot();
        }
        HudUi.GameStart = true;
    }

    void Callback_WaveState()
    {

    }

    void Callback_ResultState()
    {
        GameUi.Init();
        HudUi.Init();
        //StopAllCoroutines();
        HudUi.ResultGame.GetComponent<ResultGameDlg>().OpenUI();
        HudUi.StopWatch.gameObject.SetActive(false);
    }
}
