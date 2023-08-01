using System;
using System.Collections.Generic;

[Serializable]
public class TotalReserveAmount
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


    public TotalReserveAmount(
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


    //元金計算
    public List<int> PrincipalCalculation()
    {
        var principals = new List<int>();

        int principal = _initalAmount.Amaunt;
        principals.Add(principal);
        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                principal += _reserveAmount.Amaunt;
                principals.Add(principal);
            }
        }

        var result = new List<int>(principal);
        return result;
    }


    //月複利計算(タプル返却があまりよくないが現状思いつかないのでこれで対応
    public (List<int>, List<float>) MonthlyInterestCaluculation()
    {
        var afterMonthPrincipals = new List<int>();
        var monthRates = new List<float>();

        //繰越後元金
        int afterPrincipal = _initalAmount.Amaunt;

        //金利
        float comoundYield = _compoundYield.Value / 100.0f;
        float rate = 0;


        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                //積み立て額を加算する
                afterPrincipal += _reserveAmount.Amaunt;
                //金利を計算する
                afterPrincipal += (int)rate;
                afterMonthPrincipals.Add(afterPrincipal);

                //金利データを計算する
                rate += afterPrincipal * (comoundYield / 12);
                monthRates.Add(rate);
                //計算金利
                rate = afterPrincipal * (comoundYield / 12);

            }
        }

        var result1 = new List<int>(afterMonthPrincipals);
        var result2 = new List<float>(monthRates);
        return (result1, result2);
    }


    //年利計算
    public (List<int>, List<float>) YearthInterestCaluculation()
    {
        var afterYearthPrincipals = new List<int>();
        var yearthRates = new List<float>();

        //繰越後元金
        int afterPrincipal = _initalAmount.Amaunt;

        //金利
        float comoundYield = _compoundYield.Value / 100.0f;
        float rate = 0;

        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                //積立額を追加する
                afterPrincipal += _reserveAmount.Amaunt;

                //データ用金利計算
                rate += afterPrincipal * (comoundYield / 12);
                yearthRates.Add(rate);
            }

            //年金利を加算する
            afterPrincipal += (int)rate;
            afterYearthPrincipals.Add(afterPrincipal);
        }

        var result1 = new List<int>(afterYearthPrincipals);
        var result2 = new List<float>(yearthRates);
        return (result1, result2);
    }



}























