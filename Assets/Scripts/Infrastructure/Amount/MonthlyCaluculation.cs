using System;
using System.Collections.Generic;
using UnityEngine;

//同じロジック、似たようなロジックだったとしても概念が違えばDRYにすべきではない
//DRY的に異なるもの同士を無理にDRYにすると密結合化する

[Serializable]
public class MonthlyCaluculation
{
    //初期額
    [SerializeField]
    private InitalAmount _initalAmount;
    //積み立て額
    [SerializeField]
    private ReserveAmount _reserveAmount;
    //積み立て期間
    [SerializeField]
    private AccumulationPeriod _accumulationPeriod;
    //運用利回り
    [SerializeField]
    private CompoundYield _compoundYield;

    private const int Month = 12;

    private List<ulong> _afterPrincipals = new List<ulong>();
    private List<float> _interests = new List<float>();

    public MonthlyCaluculation(
        InitalAmount initalAmount,
        ReserveAmount reserveAmount,
        AccumulationPeriod accumulationPeriod,
        CompoundYield compoundYield
        )
    {
        this._initalAmount = initalAmount;
        this._reserveAmount = reserveAmount;
        this._accumulationPeriod = accumulationPeriod;
        this._compoundYield = compoundYield;
    }

    //元本計算
    public List<ulong> PrincipalCalculation()
    {
        var principals = new List<ulong>();

        ulong principal = _initalAmount.Amount;
        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (ulong j = 0; j < Month; j++)
            {
                principal += _reserveAmount.Amount;
                principals.Add(principal);
            }
        }
        return principals;
    }

    //複利計算(月利)
    public (List<ulong>, List<float>) InterestCaluculation()
    {
        _afterPrincipals = new List<ulong>();
        _interests = new List<float>();

        //繰越後元金
        ulong afterPrincipal = _initalAmount.Amount;

        //金利
        float comoundYield = _compoundYield.Value / 100.0f;
        float rate = 0;
        float interest = 0;

        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                //積み立て額を加算する
                afterPrincipal += _reserveAmount.Amount;

                //繰越元金を計算する
                afterPrincipal += (ulong)rate;
                rate = afterPrincipal * (comoundYield / 12);
                _afterPrincipals.Add(afterPrincipal);

                //金利データを計算する
                interest += Mathf.Floor(afterPrincipal * (comoundYield / 12));
                _interests.Add((int)interest);
            }
        }

        var result1 = new List<ulong>(_afterPrincipals);
        var result2 = new List<float>(_interests);
        return (result1, result2);
    }

    //税金計算
    public List<ulong> TaxCalculation(float tax)
    {
        var taxPrincipals = new List<ulong>();

        for (int i = 0; i < _interests.Count; i++)
        {
            var result = (ulong)(_interests[i] * ((100 - tax) / 100.0f));
            taxPrincipals.Add(result);
        }

        return taxPrincipals;
    }

    public List<ulong> ResultCalculation(List<ulong> principals, List<ulong> taxPrincipals)
    {
        throw new System.NotImplementedException();
    }

    public ulong TotalReverseAmount()
    {
        throw new System.NotImplementedException();
    }
}
