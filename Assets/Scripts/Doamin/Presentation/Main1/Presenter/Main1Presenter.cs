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


                //IAmauntCaluculation monthly = new MonthlyCaluculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
                //var (result1, result2) = monthly.InterestCaluculation();
                IAmauntCaluculation year = new YearthCaluculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
                //var principals = year.PrincipalCalculation();
                //foreach (var child in principals)
                //{
                //    Debug.Log(child);
                //}
                var (result1, result2) = year.InterestCaluculation();
                //foreach (var child in result1)
                //{
                //    Debug.Log(child);
                //}

                foreach (var child in result2)
                {
                    Debug.Log(child);
                }

                var tax = year.TaxCalculation(20.315f);
                foreach (var child in tax)
                {
                    //Debug.Log(child);
                }


            }).AddTo(this);

    }

}
