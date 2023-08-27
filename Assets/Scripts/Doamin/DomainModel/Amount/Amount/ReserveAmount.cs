using System;
using UnityEngine;

[Serializable]
public class ReserveAmount
{
    [SerializeField] ulong _amount;
    public ulong Amount => _amount;

    private const byte Min = 0;
    private const byte DigitMax = 7;

    public ReserveAmount(ulong amount)
    {
        if (amount < Min)
        {
            throw new ArgumentException("積み立て額は0以上を指定してください");
        }

        if (DigitMax < Digit(amount))
        {
            throw new ArgumentException("初期額は7桁以下を指定してください");
        }

        this._amount = amount;
    }

    private ulong Digit(ulong num)
    {
        return (num == 0) ? 1 : ((ulong)Mathf.Log10(num) + 1);
    }
}

