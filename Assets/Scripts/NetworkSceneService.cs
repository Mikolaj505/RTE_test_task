using Fusion;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class NetworkSceneService : MonoBehaviour, INetworkSceneService
    {
        public INetworkSceneManager NetworkSceneManager { get; private set; }

        private void Awake()
        {
            NetworkSceneManager = GetComponent<INetworkSceneManager>();
        }

        private void OnEnable()
        {
            ServiceLocator.Register<INetworkSceneService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<INetworkSceneService>();
        }

        public INetworkSceneManager GetNetworkSceneManager() => NetworkSceneManager;
    }
}
