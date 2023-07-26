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


    [SerializeField] TextMeshProUGUI _totalReserveAmountText;
    public TextMeshProUGUI TotalReserveAmountText => _totalReserveAmountText;

    [SerializeField] Button _caluculateButton;
    public Button CaluculateButton => _caluculateButton;


}
