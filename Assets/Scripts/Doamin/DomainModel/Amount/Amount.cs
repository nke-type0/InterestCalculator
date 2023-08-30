using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//集約ルート

[Serializable]
public class Amount
{
    //[SerializeField] AmountId _amountId;
    //public AmountId AmountId => _amountId;

    [SerializeField] InitalAmount _initalAmount;
    public InitalAmount InitalAmount => _initalAmount;

    [SerializeField] ReserveAmount _reserveAmount;
    public ReserveAmount ReserveAmount => _reserveAmount;

    [SerializeField] AccumulationPeriod _accumulationPeriod;
    public AccumulationPeriod AccumulationPeriod => _accumulationPeriod;

    [SerializeField] CompoundYield _compoundYield;
    public CompoundYield CompoundYield => _compoundYield;


    public Amount(
        //AmountId amountId,
        InitalAmount initialAmount,
        ReserveAmount reserveAmount,
        AccumulationPeriod accumulationPeriod,
        CompoundYield compoundYield)
    {
        if (ReferenceEquals(initialAmount, null))
        {
            Debug.LogException(new ArgumentNullException("初期額が入力されていません"));
            return;
        }

        if (ReferenceEquals(reserveAmount, null))
        {
            Debug.LogException(new ArgumentNullException("積立額が入力されていません"));
            return;
        }

        if (ReferenceEquals(accumulationPeriod, null))
        {
            Debug.LogException(new ArgumentNullException("積立期間が入力されていません"));
            return;
        }

        if (ReferenceEquals(compoundYield, null))
        {
            Debug.LogException(new ArgumentNullException("利回りが入力されていません"));
            return;
        }

        //_amountId = amountId;
        _initalAmount = initialAmount;
        _reserveAmount = reserveAmount;
        _accumulationPeriod = accumulationPeriod;
        _compoundYield = compoundYield;
    }


}
