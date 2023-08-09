using Michsky.MUIP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;


//初期投資額 10桁の整数のみ
//毎月の積み立て額 8桁の整数以下のみ
//期間　99年整数以下
//利回り　50%少数以下


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


    public void SetTotalReserveAmount(string text)
    {
        _totalReserveAmountText.text = text;
    }

    public void SetErrorInitialAmountText(bool flag)
    {
        _errorInitialAmauntText.gameObject.SetActive(flag);
    }

    public void SetErrorReserveAmountText(bool flag)
    {
        _errorReserveAmountText.gameObject.SetActive(flag);
    }

    public void SetErrorAccumulationPeriodText(bool flag)
    {
        _errorAccumulationPeriodText.gameObject.SetActive(flag);
    }

    public void SetErrorCompoundYieldText(bool flag)
    {
        _errorCompoundYieldText.gameObject.SetActive(flag);
    }
}
