using System;
using UnityEngine;

[Serializable]
public class TotalReserveAmount
{
    [SerializeField] int _amaunt;
    public int Amaunt => _amaunt;

    public TotalReserveAmount(int amaunt)
    {
        this._amaunt = amaunt;
    }
}