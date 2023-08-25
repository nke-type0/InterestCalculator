using System;
using UnityEngine;

public class AmountId
{
    private readonly int _value;
    public int Value => _value;

    public AmountId(int id)
    {
        this._value = id;
    }
}
