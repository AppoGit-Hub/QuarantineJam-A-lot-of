using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Value = 100;
    public float MaxValue = 100;

    public void AddHealth(float h)
    {
        if (Value == MaxValue) return;

        Value = Mathf.Clamp(Value + h, 0, MaxValue);
    }
}
