using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public enum State
    {
        Stop,
        Moving
    }
        
    public Vector3 Target
    {
        get
        {
            return (GameManager.Instance.PlayerInstance == null) ? 
                Vector3.up :
                GameManager.Instance.PlayerInstance.transform.position;
        }
    }

    public float StopDistance = 0;
    public float Speed = 1;

    public State CurrentState = State.Moving;

    [SerializeField] private Rigidbody Rigidbody;

    private bool Move = true;

    private void Update()
    {
        if (Move == false) return;

        float Distance = Vector3.Distance(this.transform.position, Target);

        if (Distance >= StopDistance)
        {
            this.Rigidbody.MovePosition(this.transform.position + this.transform.forward * Speed * Time.fixedDeltaTime);
            this.CurrentState = State.Moving;
        }
        else
        {
            this.CurrentState = State.Stop;
        }


        Vector3 targetgoodpos = Target;
        targetgoodpos.y = this.transform.position.y;

        Debug.DrawRay(this.transform.position, targetgoodpos, Color.green);

        this.transform.LookAt(targetgoodpos);
    }

    private void OnCollisionStay(Collision collision)
    {
        //if (collision.transform == Target)
        //    Move = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        //Move = true;
    }
}
