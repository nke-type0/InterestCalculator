using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start1 : MonoBehaviour
{
    private async void Start()
    {

        string sceneName = new string("Main1");
        await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

    }
}
