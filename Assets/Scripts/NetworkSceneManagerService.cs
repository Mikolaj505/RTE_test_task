using Fusion;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class NetworkSceneManagerService : MonoBehaviour
    {
        public INetworkSceneManager NetworkSceneManager { get; private set; }

        private void Awake()
        {
            NetworkSceneManager = GetComponent<INetworkSceneManager>();
        }

        private void OnEnable()
        {
            ServiceLocator.Register<NetworkSceneManagerService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<NetworkSceneManagerService>();
        }
    }
}
