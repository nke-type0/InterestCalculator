using Zenject;

//Mainシーンは1つのみAddする
//Mainシーン基本的にはシーン作成、他機能との繋ぎをする場所

public class Main1Installer : MonoInstaller
{
    public override void InstallBindings()
    {

        //Infrustructure
        //Container
        //    .Bind<ISaveDataRepository>()
        //    .To<PlayerPrefsSaveDataRepsitory>()
        //    .AsCached();


        Container
            .Bind<YearthRepository>()
            .AsCached();

        Container
           .Bind<AmountRepository>()
           .AsCached();

        //ApplicationService
        Container
            .Bind<AmountApplication>()
            .AsCached();



    }
}