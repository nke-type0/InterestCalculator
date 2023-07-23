using System;
using System.Collections.Generic;
using UnityEngine;

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


    //元金
    public List<int> Principals => _principals;
    private List<int> _principals = new List<int>();
    //繰入後の元金
    public List<int> AfterPrincipals => _afterPrincipals;
    private List<int> _afterPrincipals = new List<int>();
    //利息
    public List<float> PrincipalsRates => _principalsRates;
    private List<float> _principalsRates = new List<float>();


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
    public void PrincipalCalculation()
    {
        _principals = new List<int>();

        int principal = _initalAmount.Amaunt;
        _principals.Add(principal);
        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                principal += _reserveAmount.Amaunt;
                Debug.Log(principal);
                _principals.Add(principal);
            }
        }

    }

    //繰入後元金計算
    public void RatePrincipalCaluculation()
    {
        _afterPrincipals = new List<int>();
        _principalsRates = new List<float>();

        //元金, 繰越後元金
        int afterPrincipal = _initalAmount.Amaunt;
        _afterPrincipals.Add(afterPrincipal);

        //金利
        float comoundYield = _compoundYield.Value / 100.0f;
        float rate = 0;

        //年数
        for (int i = 0; i < _accumulationPeriod.Value; i++)
        {
            //1年間
            for (int j = 0; j < 12; j++)
            {
                afterPrincipal += _reserveAmount.Amaunt;
                _afterPrincipals.Add(afterPrincipal);

                rate += afterPrincipal * (comoundYield / 12);
                _principalsRates.Add(rate);

                //毎回金利加算(月複利)
                rate = afterPrincipal * (comoundYield / 12);
                afterPrincipal += (int)rate;
                _afterPrincipals.Add(afterPrincipal);
                //Debug.Log(afterPrincipal);
            }

            ////1年後金利加算(年複利)
            //principal += (int)rate;
            //Debug.Log(principal);
            //rate = 0;
        }
    }



}



////利息計算
//public List<float> RateCaluculation()
//{
//    float comoundYield = _compoundYield.Value / 100.0f;
//    float rate = 0;
//    foreach (var principal in _principals)
//    {
//        rate += principal * comoundYield / 12;
//        _principalsRates.Add(rate);
//    }

//    List<float> Test = new List<float>(_principalsRates);
//    return Test;
//}






























