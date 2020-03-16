using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private FollowTarget FT;
    [SerializeField] private Gun Gun;

    [SerializeField] [Range(5, 30)] private float Range;
    [SerializeField] [Range(0, 120)] private int ShootRate;

    private StopWatch Waiter = new StopWatch();

    private void Start()
    {
        Waiter.SetWait(Gun.Shoot, ShootRate, 0, true);
    }


    private void Update()
    {
        if (FT.CurrentState == FollowTarget.State.Stop || Vector3.Distance(this.transform.position, FT.Target) <= Range)
        {
            Waiter.Update();
        }                
    }
}
