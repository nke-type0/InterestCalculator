using System;
using UnityEngine;

[Serializable]
public class CompoundYield
{
    [SerializeField] double _value;
    public double Value => _value;

    private const byte Min = 0;
    private const byte Max = 20;

    public CompoundYield(double value)
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
    private const double Percent = 100.0f;

    public double Percentage()
    {
        return _value / Percent;
    }

}
