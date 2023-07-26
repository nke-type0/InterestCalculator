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


        _main1View.CaluculateButton.OnClickAsObservable()
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


                    TotalReserveAmount totalReserveAmount = new TotalReserveAmount(
                        initalAmount, reserveAmount, accumulationPeriod, compoundYield);

                    //totalReserveAmount.PrincipalCalculation();
                    totalReserveAmount.RatePrincipalCaluculation();


                }).AddTo(this);

    }

}
