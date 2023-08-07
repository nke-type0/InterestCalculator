using System.Collections.Generic;
using UnityEngine;

public class MonthlyCaluculation : IAmauntCaluculation
{
    //初期額
    private InitalAmount _initalAmount;
    //積み立て額
    private ReserveAmount _reserveAmount;
    //積み立て期間
    private AccumulationPeriod _accumulationPeriod;
    //運用利回り
    private CompoundYield _compoundYield;

    private const int Month = 12;

    private List<int> _afterPrincipals = new List<int>();
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
    public List<int> PrincipalCalculation()
    {
        var principals = new List<int>();

        int principal = _initalAmount.Amaunt;
        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                principal += _reserveAmount.Amaunt;
                principals.Add(principal);
            }
        }
        return principals;
    }

    //複利計算(月利)
    public (List<int>, List<float>) InterestCaluculation()
    {
        _afterPrincipals = new List<int>();
        _interests = new List<float>();

        //繰越後元金
        int afterPrincipal = _initalAmount.Amaunt;

        //金利
        float comoundYield = _compoundYield.Value / 100.0f;
        float rate = 0;
        float interest = 0;

        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                //積み立て額を加算する
                afterPrincipal += _reserveAmount.Amaunt;

                //繰越元金を計算する
                afterPrincipal += (int)rate;
                rate = afterPrincipal * (comoundYield / 12);
                _afterPrincipals.Add(afterPrincipal);

                //金利データを計算する
                interest += Mathf.Floor(afterPrincipal * (comoundYield / 12));
                _interests.Add((int)interest);
            }
        }

        var result1 = new List<int>(_afterPrincipals);
        var result2 = new List<float>(_interests);
        return (result1, result2);
    }

    //税金計算
    public List<int> TaxCalculation(float tax)
    {
        var taxPrincipals = new List<int>();

        for (int i = 0; i < _interests.Count; i++)
        {
            var result = (int)(_interests[i] * ((100 - tax) / 100.0f));
            taxPrincipals.Add(result);
        }

        return taxPrincipals;
    }

    public List<int> ResultCalculation(List<int> principals, List<int> taxPrincipals)
    {
        throw new System.NotImplementedException();
    }

    public int TotalReverseAmount()
    {
        throw new System.NotImplementedException();
    }
}
