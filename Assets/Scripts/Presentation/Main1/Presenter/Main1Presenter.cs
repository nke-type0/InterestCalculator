using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using System.Threading;

public class Main1Presenter : MonoBehaviour
{

    [Inject] private Main1View _main1View;
    [Inject] private Main1Model _main1Model;

    private void Start()
    {
        //初期化
        _main1View.SetTotalReserveAmount(0);
        _main1View.CaluculateButton.Interactable(false);

        //初期額
        _main1View.InitialAmountInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorInitialAmauntText.gameObject.SetActive(false);
            _main1View.CaluculateButton.Interactable(true);
            _main1Model.InitalAmount(_main1View.InitialAmountInput.text);
            _main1Model.ReserveAmount(_main1View.ReserveAmountInput.text);
            _main1Model.AccumulationPeriod(_main1View.AccumulationPeriodInput.text);
            _main1Model.CompoundYield(_main1View.CompoundYieldInput.text);
        }).AddTo(this);

        //積立額
        _main1View.ReserveAmountInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorReserveAmountText.gameObject.SetActive(false);
            _main1View.CaluculateButton.Interactable(true);
            _main1Model.InitalAmount(_main1View.InitialAmountInput.text);
            _main1Model.ReserveAmount(_main1View.ReserveAmountInput.text);
            _main1Model.AccumulationPeriod(_main1View.AccumulationPeriodInput.text);
            _main1Model.CompoundYield(_main1View.CompoundYieldInput.text);
        }).AddTo(this);

        //積立年数
        _main1View.AccumulationPeriodInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorAccumulationPeriodText.gameObject.SetActive(false);
            _main1View.CaluculateButton.Interactable(true);
            _main1Model.InitalAmount(_main1View.InitialAmountInput.text);
            _main1Model.ReserveAmount(_main1View.ReserveAmountInput.text);
            _main1Model.AccumulationPeriod(_main1View.AccumulationPeriodInput.text);
            _main1Model.CompoundYield(_main1View.CompoundYieldInput.text);
        }).AddTo(this);

        //利率
        _main1View.CompoundYieldInput.onEndEdit.AsObservable().Subscribe(str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorCompoundYieldText.gameObject.SetActive(false);
            _main1View.CaluculateButton.Interactable(true);
            _main1Model.InitalAmount(_main1View.InitialAmountInput.text);
            _main1Model.ReserveAmount(_main1View.ReserveAmountInput.text);
            _main1Model.AccumulationPeriod(_main1View.AccumulationPeriodInput.text);
            _main1Model.CompoundYield(_main1View.CompoundYieldInput.text);
        }).AddTo(this);



        //計算ボタン押された時
        _main1View.CaluculateButton.onClick.AsObservable()
            .Subscribe(async _ =>
            {
                //計算処理をModelで叩きたい
                //var result = _main1Model.YearthCalculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
                //_main1View.SetTotalReserveAmount(result);
            }).AddTo(this);



        //エラー処理
        _main1Model.ErrorInitialAmountReact.Subscribe(ex =>
        {
            _main1View.ErrorInitialAmauntText.gameObject.SetActive(true);
        }).AddTo(this);

        _main1Model.ErrorReserveAmountReact.Subscribe(ex =>
        {
            _main1View.ErrorReserveAmountText.gameObject.SetActive(true);
        }).AddTo(this);

        _main1Model.ErrorAccumulationPeriodReact.Subscribe(ex =>
        {
            _main1View.ErrorAccumulationPeriodText.gameObject.SetActive(true);
        }).AddTo(this);

        _main1Model.ErrorCommandYeldReact.Subscribe(ex =>
        {
            _main1View.ErrorCompoundYieldText.gameObject.SetActive(true);
        }).AddTo(this);

        _main1Model.ConfirmCalcuButtonReact.Subscribe(ex =>
        {
            _main1View.CaluculateButton.Interactable(false);
        }).AddTo(this);
    }


}



