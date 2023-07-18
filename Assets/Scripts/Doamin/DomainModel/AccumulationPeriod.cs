using System;
using UnityEngine;

[Serializable]
public class AccumulationPeriod
{
    [SerializeField] int _value;
    public int Value => _value;

    private const int Min = 1;
    private const int Max = 999;

    public AccumulationPeriod(int value = 1)
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
