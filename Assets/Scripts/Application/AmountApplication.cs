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
    private readonly MonthRepository _yearthRepository; //これをインターフェースにすれば良いか
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();

    public AmountApplication(
        AmountRepository amountRepository,
        MonthRepository MonthRepository
        )
    {
        this._amountRepository = amountRepository;
        this._yearthRepository = MonthRepository;
    }

    //初期化(Post)ローカルorリモート
    public async UniTask PostAsync()
    {
        await _amountRepository.PostAsync();
    }

    //入力されたものを計算処理
    public decimal Calculation(Amount amount)
    {
        _yearthRepository.PrincipalsCalculation(amount);
        _yearthRepository.InterestCaluculation(amount);
        return _yearthRepository.GetResultCalculation();
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



