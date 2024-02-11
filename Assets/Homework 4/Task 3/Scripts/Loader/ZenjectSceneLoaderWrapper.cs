using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Homework4.Task3
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader zenjectSceneLoader)
            => _zenjectSceneLoader = zenjectSceneLoader;

        public void Load(Action<DiContainer> action, int sceneID)
            => _zenjectSceneLoader.LoadScene(sceneID, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}