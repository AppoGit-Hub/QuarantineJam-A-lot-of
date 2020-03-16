using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopWatch
{
    public enum State
    {
        Playing,
        Pause,
        Stopped,        
    }    
    
    
    public UnityAction FinishFunction;

    private int _CurrenTime;
    public int CurrentTime
    {
        get
        {
            return _CurrenTime;
        }
    }

    
    private int _Time;
    private bool _AutoReset;
    private int _Deviation;

    private StopWatch.State _CurrentState = State.Stopped;
    public StopWatch.State CurrentState
    {
        get
        {
            return this._CurrentState;
        }
    }

    public void Update()
    {        
        if (this._CurrentState == State.Playing)
        {
            if (this._CurrenTime > 0)
            {
                this._CurrenTime--;
            }
            else if (this._CurrenTime == 0)
            {
                this.Finish();
                //Debug.Log("Finish Decrement");
            }
        }
    }
    public void Play()
    {
        this._CurrentState = State.Playing;
    }
    public void Pause()
    {
        this._CurrentState = State.Pause;
    }
    public void Stop()
    {
        _CurrenTime = -1;
        this._CurrentState = State.Stopped;
    }
    public void ResetWatch()
    {
        this._CurrenTime = this._Time + ((int)Random.Range(-this._Deviation, this._Deviation));
    
    }

    private void Begin()
    {
        this.ResetWatch();
        this.Play();
    }
    private void Finish()
    {
        this.FinishFunction();

        if (this._AutoReset)
            this.ResetWatch();
        else
            this.Stop();
    }

    public void SetWait(UnityAction f, int WaitFrame, int Deviation, bool AutoReset)
    {
        this._Time = WaitFrame;
        this._Deviation = Deviation;
        this._AutoReset = AutoReset;
        this.FinishFunction = f;

        this.Begin();
    }

}
