using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using System.Threading;

public class Main1Presenter : MonoBehaviour
{
    private CancellationTokenSource _cts = new CancellationTokenSource();

    [Inject] private Main1View _main1View;
    [Inject] private Main1Model _main1Model;


    private void Start()
    {

        //初期額
        _main1View.InitialAmountInput.onEndEdit.AsObservable().Subscribe(async str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorInitialAmauntText.gameObject.SetActive(false);
            await _main1Model.InitalAmount(str, _cts.Token);
        }).AddTo(this);
        //積立額
        _main1View.ReserveAmountInput.onEndEdit.AsObservable().Subscribe(async str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorReserveAmountText.gameObject.SetActive(false);
            await _main1Model.ReserveAmount(str, _cts.Token);
        }).AddTo(this);
        //積立年数
        _main1View.AccumulationPeriodInput.onEndEdit.AsObservable().Subscribe(async str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorAccumulationPeriodText.gameObject.SetActive(false);
            await _main1Model.AccumulationPeriod(str, _cts.Token);
        }).AddTo(this);
        //利率
        _main1View.CompoundYieldInput.onEndEdit.AsObservable().Subscribe(async str =>
        {
            Debug.Log("!!!" + str);
            _main1View.ErrorCompoundYieldText.gameObject.SetActive(false);
             await _main1Model.CompoundYield(str, _cts.Token);
        }).AddTo(this);



        //計算ボタン押された時
        _main1View.CaluculateButton.onClick.AsObservable()
            .Subscribe(async _ =>
            {
                _main1View.ErrorInitialAmauntText.gameObject.SetActive(false);
                _main1View.ErrorReserveAmountText.gameObject.SetActive(false);
                _main1View.ErrorAccumulationPeriodText.gameObject.SetActive(false);
                _main1View.ErrorCompoundYieldText.gameObject.SetActive(false);

                InitalAmount initalAmount = await _main1Model.InitalAmount(_main1View.InitialAmountInput.text.ToString(), _cts.Token);
                ReserveAmount reserveAmount = await _main1Model.ReserveAmount(_main1View.ReserveAmountInput.text.ToString(), _cts.Token);
                AccumulationPeriod accumulationPeriod = await _main1Model.AccumulationPeriod(_main1View.AccumulationPeriodInput.text.ToString(), _cts.Token);
                CompoundYield compoundYield = await _main1Model.CompoundYield(_main1View.CompoundYieldInput.text.ToString(), _cts.Token);

                var result = _main1Model.YearthCalculation(initalAmount, reserveAmount, accumulationPeriod, compoundYield);
                _main1View.SetTotalReserveAmount(result);
            }).AddTo(this);




        //エラー処理
        _main1Model.ErrorInitialAmountReact.Subscribe(ex =>
        {
            Debug.Log(ex);
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

    }



    private void OnDestroy()
    {
        _cts.Dispose();
    }

}



