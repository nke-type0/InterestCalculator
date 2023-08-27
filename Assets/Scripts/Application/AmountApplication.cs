using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Linq;

//Domain層, Infra層のメソッドを呼び出すだけにできれば理想
//(UI層のPresenterのようにできれば理想)

public class AmountApplication
{
    private readonly AmountRepository _amountRepository;
    private readonly YearthRepository _yearthRepository; //これをインターフェースにすれば良いか
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();

    public AmountApplication(
        AmountRepository amountRepository,
        YearthRepository yearthCaluculation
        )
    {
        this._amountRepository = amountRepository;
        this._yearthRepository = yearthCaluculation;
    }

    //初期化(Post)ローカルorリモート
    public async UniTask PostAmountAsync()
    {
        await _amountRepository.PostAmountAsync();
    }

    //入力されたものを計算処理
    public ulong Calculation(Amount amount)
    {
        _yearthRepository.PrincipalCalculation(amount);
        _yearthRepository.InterestCaluculation(amount);
        _yearthRepository.TaxCalculation();
        _yearthRepository.ResultCalculation();
        return _yearthRepository.GetResultAmount();
    }



    ////元本計算
    //public async UniTask PrincipalCalculationAsync(int id)
    //{
    //    //DBからデータを取得(ここをただの引数、Amountに変えて入力値から持って来ればローカルのみのものになる。。。)
    //    Amount amount = _amountRepository.FindById(id);

    //    //これで計算を動かしてる
    //    _yearthRepository.PrincipalCalculation(amount);
    //}

    ////複利計算
    //public async UniTask InterestCaluculationAsync(int id)
    //{
    //    Amount amount = _amountRepository.FindById(id);
    //    _yearthRepository.InterestCaluculation(amount);
    //}

    ////税金計算
    //public async UniTask TaxCalculationAsync()
    //{
    //    _yearthRepository.TaxCalculation();
    //}

    ////税引後元金合計(元金＋複利後利息)
    //public async UniTask ResultCalculationAsync()
    //{
    //    _yearthRepository.ResultCalculation();
    //}

    //public async UniTask<ulong> YeathCalculation(int id)
    //{
    //    Amount amount = _amountRepository.FindById(id);
    //    _yearthRepository.PrincipalCalculation(amount);
    //    _yearthRepository.InterestCaluculation(amount);
    //    _yearthRepository.TaxCalculation();
    //    _yearthRepository.ResultCalculation();
    //    return _yearthRepository.GetResultAmount();
    //}



    public void OnDestroy()
    {
        _cts.Cancel();
    }

}



