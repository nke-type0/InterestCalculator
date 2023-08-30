using System;
using UnityEngine;

[Serializable]
public class AccumulationPeriod
{
    [SerializeField] float _value;
    public float Value => _value;

    private const byte Min = 1;
    private const byte Max = 50;

    public AccumulationPeriod(float value)
    {
        if (value < Min)
        {
            throw new ArgumentException("積み立て期間は1以上を指定してください");
        }
        if (Max < value)
        {
            throw new ArgumentException("積み立て期間は" + Max + "より小さな値を指定してください");
        }
        this._value = value;
    }
}
