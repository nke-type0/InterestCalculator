using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

//初期投資額 9桁の整数のみ
//毎月の積み立て額 7桁の整数以下のみ
//期間　1~50年
//利回り　年利1~20%

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
    public void InitalAmount(string initial)
    {
        try
        {
            InitalAmount initalAmount = new InitalAmount(ulong.Parse(initial.ToString()));
        }
        catch (Exception ex)
        {
            _errorInitialAmountReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }

    //積立額
    public void ReserveAmount(string reserve)
    {
        try
        {
            ReserveAmount reserveAmount = new ReserveAmount(ulong.Parse(reserve.ToString()));
        }
        catch (Exception ex)
        {
            _errorReserveAmountReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }

    //積立年数
    public void AccumulationPeriod(string accumulation)
    {
        try
        {
            AccumulationPeriod accumulationPeriod = new AccumulationPeriod(byte.Parse(accumulation.ToString()));
        }
        catch (Exception ex)
        {
            _errorAccumulationPeriodReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }

    //利率
    public void CompoundYield(string compound)
    {
        try
        {
            CompoundYield compoundYield = new CompoundYield(decimal.Parse(compound.ToString()));
        }
        catch (Exception ex)
        {
            _errorCommandYeldReact.Value = ex;
            _confirmCalcuButtonReact.Value = ex;
        }
    }


    //複利計算
    public decimal Calculation(
        string initial,
        string reserve,
        string accumulation,
        string compound)
    {
        try
        {
            InitalAmount initalAmount = new InitalAmount(ulong.Parse(initial.ToString()));
            ReserveAmount reserveAmount = new ReserveAmount(ulong.Parse(reserve.ToString()));
            AccumulationPeriod accumulationPeriod = new AccumulationPeriod(byte.Parse(accumulation.ToString()));
            CompoundYield compoundYield = new CompoundYield(decimal.Parse(compound.ToString()));

            Amount amount = new Amount(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
            return _amountApplication.Calculation(amount);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
            throw ex;
        }
    }

}


