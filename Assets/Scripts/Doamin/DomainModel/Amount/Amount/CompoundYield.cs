using System;
using UnityEngine;

[Serializable]
public class CompoundYield
{
    [SerializeField] int _value;
    public int Value => _value;

    private const int Min = 0;

    public CompoundYield(int value)
    {
        if (value < Min)
        {
            throw new ArgumentException("利回りは0以上を指定してください");
        }

        //少数で受け取って、小数点第一は切り捨てて代入するのがいいのかな？


        this._value = value;
    }

    //百分率計算を置いておくのが良さげ
    //Percentage();

    public bool CheckInstance()
    {
        if (ReferenceEquals(this, null))
        {
            return false;
        }
        return true;
    }
}
