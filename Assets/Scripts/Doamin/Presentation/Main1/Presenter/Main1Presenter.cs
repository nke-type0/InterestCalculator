using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class Main1Presenter : MonoBehaviour
{

    [Inject] private Main1View _main1View;
    [Inject] private Main1Model _main1Model;

    private async void Start()
    {

        //入力処理
        _main1View.InitialAmountInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.SetErrorInitialAmountText(false);
            _main1Model.PostInitalAmount(str);
        }).AddTo(this);

        _main1View.ReserveAmountInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.SetErrorReserveAmountText(false);
            _main1Model.PostReserveAmount(str);
        }).AddTo(this);

        _main1View.AccumulationPeriodInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.SetErrorAccumulationPeriodText(false);
            _main1Model.PostAccumulationPeriod(str);
        }).AddTo(this);

        _main1View.CompoundYieldInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.SetErrorCompoundYieldText(false);
            _main1Model.PostCommandYeld(str);
        }).AddTo(this);


        _main1View.CaluculateButton.onClick.AsObservable()
            .Subscribe(_ =>
            {
                //利率
                CompoundYield compoundYield = new CompoundYield(int.Parse(_main1View.CompoundYieldInput.text.ToString()));

                //初期額
                InitalAmount initalAmount = new InitalAmount(int.Parse(_main1View.InitialAmountInput.text.ToString()));

                //積立額
                ReserveAmount reserveAmount = new ReserveAmount(int.Parse(_main1View.ReserveAmountInput.text.ToString()));

                //積立年数
                AccumulationPeriod accumulationPeriod = new AccumulationPeriod(int.Parse(_main1View.AccumulationPeriodInput.text.ToString()));



                IAmauntCaluculation year = new YearthCaluculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
                var principals = year.PrincipalCalculation();
                ////元金
                //foreach (var child in principals)
                //{
                //    Debug.Log(child);
                //}

                var (result1, result2) = year.InterestCaluculation();
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
                var tax = year.TaxCalculation(20.315f);
                //foreach (var child in tax)
                //{
                //    Debug.Log(child);
                //}

                //税引後元金合計(元金＋複利後利息)
                var results = year.ResultCalculation(principals, tax);

                var totalReserverAmaunt = year.TotalReverseAmount();
                _main1View.SetTotalReserveAmount(totalReserverAmaunt.ToString());

            }).AddTo(this);




        //エラー処理
        _main1Model.ErrorInitialAmountReact.Subscribe(ex =>
        {
            Debug.Log(ex);
            _main1View.SetErrorInitialAmountText(true);
        }).AddTo(this);

        _main1Model.ErrorReserveAmountReact.Subscribe(ex =>
        {
            _main1View.SetErrorReserveAmountText(true);
        }).AddTo(this);

        _main1Model.ErrorAccumulationPeriodReact.Subscribe(ex =>
        {
            _main1View.SetErrorAccumulationPeriodText(true);
        }).AddTo(this);

        _main1Model.ErrorCommandYeldReact.Subscribe(ex =>
        {
            _main1View.SetErrorCompoundYieldText(true);
        }).AddTo(this);




    }

}
