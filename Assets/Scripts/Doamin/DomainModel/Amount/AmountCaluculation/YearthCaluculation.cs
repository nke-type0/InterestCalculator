using System.Collections.Generic;
using UnityEngine;

public class YearthCaluculation : IAmauntCaluculation
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

    public YearthCaluculation(
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

    //複利計算(年利)
    public (List<int>, List<float>) InterestCaluculation()
    {
        _afterPrincipals = new List<int>();
        _interests = new List<float>();

        //繰越後元金
        int afterPrincipal = _initalAmount.Amaunt;

        //金利
        float comoundYield = _compoundYield.Value / 100.0f;
        float interest = 0;

        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                //積み立て額を加算する
                afterPrincipal += _reserveAmount.Amaunt;
                _afterPrincipals.Add(afterPrincipal);

                interest += Mathf.Floor(afterPrincipal * (comoundYield / 12));
            }

            //年間金利計算
            afterPrincipal += (int)interest;
            _interests.Add((int)interest);
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

}
