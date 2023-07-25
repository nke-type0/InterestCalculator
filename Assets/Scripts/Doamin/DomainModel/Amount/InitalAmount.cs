using System;
using UnityEngine;

[Serializable]
public class InitalAmount
{
    [SerializeField] int _amaunt;
    public int Amaunt => _amaunt;

    public InitalAmount(int amaunt)
    {
        this._amaunt = amaunt;
    }
}
