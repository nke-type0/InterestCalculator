using System;
using UnityEngine;

[Serializable]
public class AccumulationPeriod
{
    [SerializeField] int _periodValue;
    public int Amaunt => _periodValue;

    private const int Min = 1;
    private const int Max = 999;

    public AccumulationPeriod(int periodValue)
    {
        if (periodValue < Min)
        {
            throw new ArgumentException("積み立て期間は1以上を指定してください");
        }
        if (Max < periodValue)
        {
            throw new ArgumentException("積み立て期間は" + Max + "より小さな値を指定してください");
        }
        this._periodValue = periodValue;
    }
}
