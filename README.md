

# MVPProject

MVP開発手法用(必要最低限の価値を提供できるプロダクトを作成し、ユーザーのニーズを検証し製品サービスを近づける)
基盤として再利用できる機能を作成する場所。

全体アーキテクト : オニオンアーキテクチャ

UI層 : MVPデザインパターン

ロジック層 : ApplicationService, Infrastructure, Domain

Test : UnityTestRunner, Extenject

![20171011060911](https://user-images.githubusercontent.com/52362979/233418627-01568be1-820f-4d21-aa4b-63341c684687.png)


## 実装済み機能
マルチシーンエディティング(複数人チーム開発)

アバター生成(CharactorController)

移動ロジック(InputSystem)

カメラ動作(Cinemachine)

UnityTestRunner(ローカルテスト、単体テスト、状態遷移テストが可能)

AssemblyDifinesonsFiles(依存関係の切り分け)

Addressable

ScriptableObject

UniversalRenderPipline設定

Lighting設定

TextMeshPro設定

BaaS接続(UnityGamingService, Firebase等)

3Dオブジェクト生成+タップ処理

シーンを跨いで使用するApplicationService管理

シーンを跨いで使用するView管理

例外処理

タイムアウト処理

他のシーンに依存させない


## 実装予定機能

音声チャット(Vivox)

サーバークライアント接続(NetCode)

Localization(多言語化)

Addressable暗号化(セキュリティ)






## 採用サードパーティ製アセット
UniRx, UniTask ,Extenject

## License & Copyright
Copyright (c) 2018 Yoshifumi Kawai  
[https://github.com/neuecc/UniRx/blob/master/LICENSE](https://github.com/neuecc/UniRx/blob/master/LICENSE)  

Copyright (c) 2019 Yoshifumi Kawai / Cysharp, Inc.  
[https://github.com/Cysharp/UniTask/blob/master/LICENSE](https://github.com/Cysharp/UniTask/blob/master/LICENSE)

Copyright (c) 2010-2019 Modest Tree Media Inc.  
[https://github.com/modesttree/Zenject/blob/master/License.md](https://github.com/modesttree/Zenject/blob/master/License.md)  


