using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//この中でロジックをになっているところをコレクションオブジェクトにするとよりわかりやすくなる

public class YearthRepository
{
    //月数
    private const int Month = 12;
    //百分率
    private const float Percent = 100.0f;
    //税金
    private const float Tax = 20.315f;

    private List<ulong> _principals = new List<ulong>();
    private List<ulong> _afterPrincipals = new List<ulong>();
    private List<float> _interests = new List<float>();
    private List<ulong> _taxPrincipals = new List<ulong>();
    private List<ulong> _results = new List<ulong>();


    //元本計算
    public void PrincipalCalculation(Amount amount)
    {
        _principals = new List<ulong>();

        ulong principal = amount.InitalAmount.Amount;
        for (int i = 0; i < amount.AccumulationPeriod.Value; i++)
        {
            for (ulong j = 0; j < Month; j++)
            {
                principal += amount.ReserveAmount.Amount;
                _principals.Add(principal);
            }
        }
    }


    //複利計算(年利)
    public void InterestCaluculation(Amount amount)
    {
        _afterPrincipals = new List<ulong>();
        _interests = new List<float>();

        //繰越後元金
        ulong afterPrincipal = amount.InitalAmount.Amount;

        //金利
        float comoundYield = amount.CompoundYield.Percentage();
        float interest = 0;

        for (int i = 0; i < amount.AccumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                //積み立て額を加算する
                afterPrincipal += amount.ReserveAmount.Amount;
                _afterPrincipals.Add(afterPrincipal);

                interest += Mathf.Floor(afterPrincipal * (comoundYield / Month));
            }

            //年間金利計算
            afterPrincipal += (ulong)interest;
            _interests.Add((int)interest);
        }
    }


    //税金計算
    public void TaxCalculation()
    {
        _taxPrincipals = new List<ulong>();

        for (int i = 0; i < _interests.Count; i++)
        {
            var result = (ulong)(_interests[i] * ((100 - Tax) / Percent));
            _taxPrincipals.Add(result);
        }
    }


    //税引後元金合計(元金＋複利後利息)
    public void ResultCalculation()
    {
        _results = new List<ulong>();

        int num = 1;
        int taxNum = 0;
        foreach (var child in _principals)
        {
            if (num % 12 == 0)
            {
                var result = child + _taxPrincipals[taxNum++];
                _results.Add(result);
                num = 1;
            }
            num++;
        }
    }


    public ulong GetResultAmount()
    {
        return _results.Max();
    }
}
