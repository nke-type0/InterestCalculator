using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

public class Main1Model : MonoBehaviour
{

    [Inject] private AmountApplication _amountApplication;

    private ReactiveProperty<Exception> _errorInitialAmountReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorInitialAmountReact => _errorInitialAmountReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _errorReserveAmountReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorReserveAmountReact => _errorReserveAmountReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _errorAccumulationPeriodReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorAccumulationPeriodReact => _errorAccumulationPeriodReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _errorCommandYeldReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ErrorCommandYeldReact => _errorCommandYeldReact.SkipLatestValueOnSubscribe();

    private ReactiveProperty<Exception> _confirmCalcuButtonReact = new ReactiveProperty<Exception>();
    public IObservable<Exception> ConfirmCalcuButtonReact => _confirmCalcuButtonReact.SkipLatestValueOnSubscribe();

    /// <summary>
    /// DB初期化
    /// </summary>
    private async void Start()
    {
        await _amountApplication.PostAmountAsync();
    }

    /// <summary>
    /// 入力値に対する例外処理
    /// </summary>
    //初期額
    public void InitalAmount(string str)
    {
        try
        {
            InitalAmount initalAmount = new InitalAmount(ulong.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorInitialAmountReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }

    //積立額
    public void ReserveAmount(string str)
    {
        try
        {
            ReserveAmount reserveAmount = new ReserveAmount(ulong.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorReserveAmountReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }

    //積立年数
    public void AccumulationPeriod(string str)
    {
        try
        {
            AccumulationPeriod accumulationPeriod = new AccumulationPeriod(int.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorAccumulationPeriodReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }

    //利率
    public void CompoundYield(string str)
    {
        try
        {
            CompoundYield compoundYield = new CompoundYield(int.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorCommandYeldReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }








    ////計算時
    //public ulong YearthCalculation(
    //    InitalAmount initalAmount,
    //    ReserveAmount reserveAmount,
    //    AccumulationPeriod accumulationPeriod,
    //    CompoundYield compoundYield)
    //{
    //    try
    //    {

    //        YearthCaluculation yearth = new YearthCaluculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
    //        //元金計算
    //        yearth.PrincipalCalculation();
    //        yearth.InterestCaluculation();


    //        ////繰入後元金
    //        //foreach (var child in result1)
    //        //{
    //        //    Debug.Log(child);
    //        //}
    //        //利息
    //        //foreach (var child in result2)
    //        //{
    //        //    Debug.Log(child);
    //        //}
    //        //複利後利息
    //        yearth.TaxCalculation(20.315f);

    //        //税引後元金合計(元金＋複利後利息)
    //        yearth.ResultCalculation();
    //        var totalReserverAmaunt = yearth.GetResultAmount();
    //        return totalReserverAmaunt;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


}
