using System;
using UnityEngine;

[Serializable]
public class CompoundYield
{
    [SerializeField] decimal _value;
    public decimal Value => _value;

    private const byte Min = 0;
    private const byte Max = 20;

    public CompoundYield(decimal value)
    {
        if (value < Min)
        {
            throw new ArgumentException("利回りは0以上を指定してください");
        }

        if (value > Max)
        {
            throw new ArgumentException("利回りは8以下を指定してください");
        }

        this._value = value;
    }

    //百分率
    private const decimal Percent = 100.0m;

    public decimal Percentage()
    {
        return _value / Percent;
    }

}
