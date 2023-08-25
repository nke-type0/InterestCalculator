using System;
using UnityEngine;

[Serializable]
public class ReserveAmount
{
    [SerializeField] ulong _amaunt;
    public ulong Amaunt => _amaunt;

    private const int Min = 0;

    public ReserveAmount(ulong amaunt)
    {
        if (amaunt < Min)
        {
            throw new ArgumentException("積み立て額は0以上を指定してください");
        }

        this._amaunt = amaunt;
    }

    public bool CheckInstance()
    {
        if (ReferenceEquals(this, null))
        {
            return false;
        }
        return true;
    }
}

