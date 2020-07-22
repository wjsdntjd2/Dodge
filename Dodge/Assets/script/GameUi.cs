using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    public Turret[] Turret = null;
    public PlayerCtrl Player = null;
    public MapFrame Map = null;

    public void Init()
    {
        for (int i = 0; i < Turret.Length; i++)
        {
            Turret[i].Init();
        }
        //Player.Init();
    }
}
