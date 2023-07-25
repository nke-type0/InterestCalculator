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

        //仮止め実装
        ////初期額
        //InitalAmount initalAmount = new InitalAmount(5000000);
        ////積立額
        //ReserveAmount reserveAmount = new ReserveAmount(0);
        ////積立年数
        //AccumulationPeriod accumulationPeriod = new AccumulationPeriod(30);
        ////利率
        //CompoundYield compoundYield = new CompoundYield(3);

        //TotalReserveAmount totalReserveAmount = new TotalReserveAmount(
        //    initalAmount, reserveAmount, accumulationPeriod, compoundYield);

        ////totalReserveAmount.PrincipalCalculation();
        //totalReserveAmount.RatePrincipalCaluculation();




        _main1View.CaluculateButton.OnClickAsObservable()
                .Subscribe(_ => Debug.Log("")).AddTo(this);

    }

}
