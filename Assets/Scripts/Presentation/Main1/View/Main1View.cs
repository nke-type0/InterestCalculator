using Michsky.MUIP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Linq;
using System.Collections.Generic;


public class Main1View : MonoBehaviour
{
    [SerializeField] TMP_InputField _initialAmountInput;
    public TMP_InputField InitialAmountInput => _initialAmountInput;

    [SerializeField] TMP_InputField _reserveAmountInput;
    public TMP_InputField ReserveAmountInput => _reserveAmountInput;

    [SerializeField] TMP_InputField _accumulationPeriodInput;
    public TMP_InputField AccumulationPeriodInput => _accumulationPeriodInput;

    [SerializeField] TMP_InputField _compoundYieldInput;
    public TMP_InputField CompoundYieldInput => _compoundYieldInput;

    [SerializeField] ButtonManager _caluculateButton;
    public ButtonManager CaluculateButton => _caluculateButton;

    [SerializeField] TextMeshProUGUI _totalReserveAmountText;
    public TextMeshProUGUI TotalReserveAmountText => _totalReserveAmountText;


    [SerializeField] TextMeshProUGUI _errorInitialAmauntText;
    public TextMeshProUGUI ErrorInitialAmauntText => _errorInitialAmauntText;

    [SerializeField] TextMeshProUGUI _errorReserveAmountText;
    public TextMeshProUGUI ErrorReserveAmountText => _errorReserveAmountText;

    [SerializeField] TextMeshProUGUI _errorAccumulationPeriodText;
    public TextMeshProUGUI ErrorAccumulationPeriodText => _errorAccumulationPeriodText;

    [SerializeField] TextMeshProUGUI _errorCompoundYieldText;
    public TextMeshProUGUI ErrorCompoundYieldText => _errorCompoundYieldText;

    public void SetTotalReserveAmount(ulong result)
    {
        _totalReserveAmountText.text = result.ToString("N0") + "円";
    }

}


