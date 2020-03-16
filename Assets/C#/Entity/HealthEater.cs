using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEater : MonoBehaviour
{
    [SerializeField] private Health HeathOnFocus;

    private StopWatch Waiter = new StopWatch();

    void Start()
    {
        Waiter.SetWait(Descrease, 80, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        Waiter.Update();   
    }

    private void Descrease()
    {
        HeathOnFocus.Value--;
    }
}
