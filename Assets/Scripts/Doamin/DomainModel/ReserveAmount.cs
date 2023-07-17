using System;
using UnityEngine;

[Serializable]
public class ReserveAmount
{
    [SerializeField] int _amaunt;
    public int Amaunt => _amaunt;

    private const int Min = 0;

    public ReserveAmount(int amaunt)
    {
        if (amaunt < Min)
        {
            throw new ArgumentException("積み立て額は0以上を指定してください");
        }

        this._amaunt = amaunt;
    }
}

