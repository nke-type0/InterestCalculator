using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

//ロジック部分をコレクションオブジェクトやドメイン側にうつすとよりよくなりそうだが、、、
//ローカルのみでRepositoryに全て記述している
//メリットとしては実装楽、大きな修正時はこちらの方が対応は早い
//デメリットとして責務的には悪い。コードが増えていくたびに修正速度が犠牲にはなる。バランスが重要。

public class MonthRepository
{
    //月数
    private const int Month = 12;

    private List<decimal> _principals = new List<decimal>();
    private List<decimal> _interests = new List<decimal>();
    private List<decimal> _afterPrincipals = new List<decimal>();

    //元本計算
    public void PrincipalsCalculation(Amount amount)
    {
        _principals = new List<decimal>();

        var principal = amount.InitalAmount.Amount;

        for (int i = 0; i < amount.AccumulationPeriod.Value; i++)
        {
            for (int j = 0; j < Month; j++)
            {
                principal += amount.ReserveAmount.Amount;
                //Debug.Log(principal);
                _principals.Add(principal);
            }
        }
    }


    //繰入後元金計算(複利計算のため、繰入後元金を求め、利息を算出するため少しややこしい、あまりよくない)
    public void InterestCaluculation(Amount amount)
    {
        _interests = new List<decimal>();
        _afterPrincipals = new List<decimal>();

        decimal principal = amount.InitalAmount.Amount;
        decimal comoundYield = (decimal)amount.CompoundYield.Percentage();
        decimal saveInterest = 0;

        for (int i = 0; i < amount.AccumulationPeriod.Value; i++)
        {
            decimal interest = 0;
            for (int j = 0; j < Month; j++)
            {
                principal += amount.ReserveAmount.Amount;
                //Debug.Log(principal);
                _afterPrincipals.Add(principal);

                //利計算息
                interest += principal * (comoundYield / Month);
                saveInterest += principal * (comoundYield / Month);
                _interests.Add(saveInterest);
            }
            //年間ごとに加算
            principal += interest;
        }
    }

    public decimal GetResultCalculation()
    {
        return _principals.Max() + _interests.Max();
    }

}





