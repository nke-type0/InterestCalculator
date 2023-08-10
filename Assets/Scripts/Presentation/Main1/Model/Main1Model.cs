using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

//今回はApplicationService層の仕事も任せる
public class Main1Model : MonoBehaviour
{

    //Error通知
    private ReactiveProperty<Exception> _errorInitialAmountReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorInitialAmountReact => _errorInitialAmountReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _errorReserveAmountReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorReserveAmountReact => _errorReserveAmountReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _errorAccumulationPeriodReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorAccumulationPeriodReact => _errorAccumulationPeriodReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _errorCommandYeldReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorCommandYeldReact => _errorCommandYeldReact.SkipLatestValueOnSubscribe();


    //初期額
    public async UniTask<InitalAmount> InitalAmount(string str, CancellationToken token)
    {
        try
        {
            InitalAmount initalAmount = new InitalAmount(int.Parse(str.ToString()));
            await UniTask.Yield(token);
            return initalAmount;
        }
        catch (Exception ex)
        {
            _errorInitialAmountReact.Value = ex;
            throw ex;
        }
    }

    //積立額
    public async UniTask<ReserveAmount> ReserveAmount(string str, CancellationToken token)
    {
        try
        {
            ReserveAmount reserveAmount = new ReserveAmount(int.Parse(str.ToString()));
            await UniTask.Yield(token);
            return reserveAmount;
        }
        catch (Exception ex)
        {
            _errorReserveAmountReact.Value = ex;
            throw ex;
        }
    }

    //積立年数
    public async UniTask<AccumulationPeriod> AccumulationPeriod(string str, CancellationToken token)
    {
        try
        {
            AccumulationPeriod accumulationPeriod = new AccumulationPeriod(int.Parse(str.ToString()));
            await UniTask.Yield(token);
            return accumulationPeriod;
        }
        catch (Exception ex)
        {
            _errorAccumulationPeriodReact.Value = ex;
            throw ex;
        }
    }

    //利率
    public async UniTask<CompoundYield> CompoundYield(string str, CancellationToken token)
    {
        try
        {
            CompoundYield compoundYield = new CompoundYield(int.Parse(str.ToString()));
            await UniTask.Yield(token);
            return compoundYield;
        }
        catch (Exception ex)
        {
            _errorCommandYeldReact.Value = ex;
            throw ex;
        }
    }



    //計算時
    public int YearthCalculation(
        InitalAmount initalAmount,
        ReserveAmount reserveAmount,
        AccumulationPeriod accumulationPeriod,
        CompoundYield compoundYield)
    {
        try
        {
            IAmauntCaluculation yearth = new YearthCaluculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
            //元金計算
            var principals = yearth.PrincipalCalculation();
            var (result1, result2) = yearth.InterestCaluculation();
            ////繰入後元金
            //foreach (var child in result1)
            //{
            //    Debug.Log(child);
            //}
            //利息
            //foreach (var child in result2)
            //{
            //    Debug.Log(child);
            //}
            //複利後利息
            var tax = yearth.TaxCalculation(20.315f);

            //税引後元金合計(元金＋複利後利息)
            var results = yearth.ResultCalculation(principals, tax);
            var totalReserverAmaunt = yearth.TotalReverseAmount();
            return totalReserverAmaunt;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }


}
