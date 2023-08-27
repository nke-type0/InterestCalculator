using System;
using UnityEngine;

[Serializable]
public class CompoundYield
{
    [SerializeField] float _value;
    public float Value => _value;

    private const byte Min = 0;
    private const byte Max = 20;

    public CompoundYield(float value)
    {
        if (value < Min)
        {
            throw new ArgumentException("利回りは0以上を指定してください");
        }

        if (value > Max)
        {
            throw new ArgumentException("利回りは20以下を指定してください");
        }

        this._value = value;
    }

    //百分率
    private const float Percent = 100.0f;

    public float Percentage()
    {
        return _value / Percent;
    }

}
