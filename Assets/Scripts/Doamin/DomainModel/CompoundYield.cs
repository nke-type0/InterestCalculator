using System;
using UnityEngine;

public class CompoundYield
{
    [SerializeField] int _value;
    public int Value => _value;

    private const int Min = 0;

    public CompoundYield(int value = 0)
    {
        if (value < Min)
        {
            throw new ArgumentException("利回りは0以上を指定してください");
        }

        this._value = value;
    }
}
