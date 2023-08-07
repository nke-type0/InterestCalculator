using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;

public class Main1Presenter : MonoBehaviour
{

    [Inject] private Main1View _main1View;

    private async void Start()
    {

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

    }

}
