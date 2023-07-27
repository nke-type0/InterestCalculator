using Michsky.MUIP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main1View : MonoBehaviour
{
    [SerializeField] TMP_InputField _compoundYieldInput;
    public TMP_InputField CompoundYieldInput => _compoundYieldInput;

    [SerializeField] TMP_InputField _initialAmountInput;
    public TMP_InputField InitialAmountInput => _initialAmountInput;

    [SerializeField] TMP_InputField _reserveAmountInput;
    public TMP_InputField ReserveAmountInput => _reserveAmountInput;

    [SerializeField] TMP_InputField _accumulationPeriodInput;
    public TMP_InputField AccumulationPeriodInput => _accumulationPeriodInput;

    [SerializeField] ButtonManager _caluculateButton;
    public ButtonManager CaluculateButton => _caluculateButton;

    [SerializeField] TextMeshProUGUI _totalReserveAmountText;
    public TextMeshProUGUI TotalReserveAmountText => _totalReserveAmountText;


    public void SetTotalReserveAmount(string result)
    {
        _totalReserveAmountText.text = result;
    }
}
