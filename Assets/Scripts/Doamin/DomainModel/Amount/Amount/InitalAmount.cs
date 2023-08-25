using System;
using UnityEngine;

[Serializable]
public class InitalAmount
{
    [SerializeField] ulong _amaunt;
    public ulong Amaunt => _amaunt;

    private const int Min = 0;

    public InitalAmount(ulong amaunt)
    {
        if (amaunt < Min)
        {
            throw new ArgumentException("初期額は0以上を指定してください");
        }

        this._amaunt = amaunt;
    }
}
