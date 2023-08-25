using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/AmountScriptableObject")]
public class AmountScriptableObject : ScriptableObjectInstaller<AmountScriptableObject>
{
    [SerializeField] List<Amount> _amountData;
    public List<Amount> AmountData => _amountData;

    //ローカルorリモートから読み込み
    public async UniTask<AmountScriptableObject> PostAmountAsync(CancellationToken token = default)
    {
        var handle = Addressables.LoadAssetAsync<AmountScriptableObject>("AmountBundle");
        await UniTask.WaitWhile(() => !handle.IsDone, cancellationToken: token);
        return handle.Result;
    }

    public override void InstallBindings()
    {
        Container
            .Bind<AmountScriptableObject>()
            .FromInstance(this)
            .AsCached();
    }
}
