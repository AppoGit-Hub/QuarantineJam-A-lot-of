using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//1 <= x >= 0
public struct Union
{
    private float _value;

    public float Value
    {
        set
        {
            if (value >= 0 && value <= 1)
                _value = value;
            else
                Mathf.Clamp(value, 0, 1);
        }
        get
        {
            return _value;
        }
    }

    public Union (float v)
    {
        _value = 0;
        Value = v;
    }
}
