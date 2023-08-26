using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

//DBの仕事

public class AmountRepository
{
    private readonly AmountScriptableObject _amountScriptable;
    private readonly TimeoutController _timeoutController;
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();

    public AmountRepository(
        AmountScriptableObject amountScriptable

    )
    {
        this._amountScriptable = amountScriptable;
        this._timeoutController = new TimeoutController(_cts);
    }


    //データベース初期化(Post)ローカルorリモート
    public async UniTask PostAmountAsync()
    {
        try
        {
            var data = await _amountScriptable.PostAmountAsync(_timeoutController.Timeout(TimeSpan.FromSeconds(5)));
            _amountScriptable.AmountData.Clear();
            foreach (var child in data.AmountData)
            {
                _amountScriptable.AmountData.Add(child);
            }
            _timeoutController.Reset();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //Amount返却
    public Amount FindById(int id)
    {
        var data = _amountScriptable.AmountData[id];
        var amount = new Amount(data.InitalAmount, data.ReserveAmount, data.AccumulationPeriod, data.CompoundYield);
        return amount;
    }

}





