using System;
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
    public void PostInitalAmount(string str)
    {
        try
        {
            InitalAmount initalAmount = new InitalAmount(int.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorInitialAmountReact.Value = ex;
            throw ex;
        }
    }

    //積立額
    public void PostReserveAmount(string str)
    {
        try
        {
            ReserveAmount reserveAmount = new ReserveAmount(int.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorReserveAmountReact.Value = ex;
            throw ex;
        }
    }

    //積立年数
    public void PostAccumulationPeriod(string str)
    {
        try
        {
            AccumulationPeriod accumulationPeriod = new AccumulationPeriod(int.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorAccumulationPeriodReact.Value = ex;
            throw ex;
        }
    }

    //利率
    public void PostCommandYeld(string str)
    {
        try
        {
            CompoundYield compoundYield = new CompoundYield(int.Parse(str.ToString()));
        }
        catch (Exception ex)
        {
            _errorCommandYeldReact.Value = ex;
            throw ex;
        }
    }



    //計算時



}
