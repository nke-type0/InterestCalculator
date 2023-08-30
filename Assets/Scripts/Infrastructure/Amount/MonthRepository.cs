using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//ロジック部分をコレクションオブジェクトやドメイン側にうつすとよりよくなりそうだが、、、
//ローカルのみでRepositoryに全て記述している
//メリットとしては実装楽、大きな修正時はこちらの方が対応は早い
//デメリットとして責務的には悪い。コードが増えていくたびに修正速度が犠牲にはなる。バランスが重要。

public class MonthRepository
{
    //月数
    private const int Month = 12;

    private List<ulong> _principals = new List<ulong>();
    private List<float> _interests = new List<float>();
    private List<ulong> _afterPrincipals = new List<ulong>();


    //元本計算
    public void PrincipalsCalculation(Amount amount)
    {
        _principals = new List<ulong>();

        var principal = amount.InitalAmount.Amount;

        for (int i = 0; i < amount.AccumulationPeriod.Value * Month; i++)
        {
            principal += amount.ReserveAmount.Amount;
            _principals.Add(principal);
        }
    }

    //複利計算(月利)
    public void InterestCaluculation(Amount amount)
    {
        _interests = new List<float>();

        var comoundYield = amount.CompoundYield.Percentage();

        for (int i = 1; i <= amount.AccumulationPeriod.Value * Month; i++)
        {
            var result = Mathf.Pow(1 + comoundYield,  i);
            _interests.Add(result);
        }
    }

    //合計
    public void AfterPrincipalsCalculation(Amount amount)
    {
        _afterPrincipals = new List<ulong>();

        for (int i = 0; i < amount.AccumulationPeriod.Value * Month; i++)
        {
            var result = (ulong)(_principals[i] * _interests[i]);
            _afterPrincipals.Add(result);
        }
    }

    public ulong GetResultAmount()
    {
        return _afterPrincipals.Max();
    }

}




