using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        //初期額
        InitalAmount initalAmount = new InitalAmount(10000);
        //積立額
        ReserveAmount reserveAmount = new ReserveAmount(10000);
        //積立年数
        AccumulationPeriod accumulationPeriod = new AccumulationPeriod(2);
        //利率
        CompoundYield compoundYield = new CompoundYield(3);



        TotalReserveAmount totalReserveAmount = new TotalReserveAmount(
            initalAmount, reserveAmount, accumulationPeriod, compoundYield);

        totalReserveAmount.PrincipalCalculation();
        //totalReserveAmount.RatePrincipalCaluculation();


        



    }



}
