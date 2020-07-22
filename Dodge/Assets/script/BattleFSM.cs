using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BattleFSM
{
    public delegate void DelegateFunc();

    public class CState
    {
        public DelegateFunc OnEnterFunc = null;

        public virtual void Init(DelegateFunc func)
        {
            OnEnterFunc = new DelegateFunc(func);
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnExit()
        {

        }
    }

    public class CReadyState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
            {
                OnEnterFunc();
            }
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }

    public class CWaveState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
            {
                OnEnterFunc();
            }
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }

    public class CGameState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
            {
                OnEnterFunc();
            }
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }

    public class CResultState : CState
    {
        public override void OnEnter()
        {
            if (OnEnterFunc != null)
            {
                OnEnterFunc();
            }
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }

    public CState curState = null;
    CState newState = null;

    public CState Ready = new CReadyState();
    public CState Game = new CGameState();
    public CState Wave = new CWaveState();
    public CState Result = new CResultState();

    public void Init(DelegateFunc kReady, DelegateFunc kGame, DelegateFunc kWave, DelegateFunc kResult)
    {
        Ready.Init(kReady);
        Game.Init(kGame);
        Wave.Init(kWave);
        Result.Init(kResult);
    }

    public void SetState(CState State)
    {
        newState = State;
    }

    public void OnUpdate()
    {
        if (newState != null)
        {
            if (curState != null)
            {
                curState.OnExit();
            }
            curState = newState;
            newState = null;
            curState.OnEnter();
        }
        if (curState != null)
        {
            curState.OnUpdate();
        }
    }

    public void SetReady()
    {
        SetState(Ready);
    }

    public void SetGame()
    {
        SetState(Game);
    }

    public void SetWave()
    {
        SetState(Wave);
    }

    public void SetResult()
    {
        SetState(Result);
    }

    public bool IsCurState(CState State)
    {
        if (curState == null)
        {
            return false;
        }
        return (curState == State) ? true : false;
    }

    public void SetNoneState()
    {
        newState = null;
        curState = null;
    }

    public bool IsResultState()
    {
        return (curState == Result) ? true : false;
    }

    public bool InNoneState()
    {
        return (curState == null) ? true : false;
    }
}