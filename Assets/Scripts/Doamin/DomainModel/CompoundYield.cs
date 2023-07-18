using System;
using UnityEngine;

public class CompoundYield
{
    [SerializeField] float _value;
    public float Value => _value;

    private const int Min = 0;

    public CompoundYield(float value = 0)
    {
        if (value < Min)
        {
            throw new ArgumentException("利回りは0以上を指定してください");
        }

        this._value = value;
    }
}
