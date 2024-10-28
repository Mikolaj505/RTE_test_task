using Cinemachine;
using MKubiak.Services;
using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class CameraSerivce : MonoBehaviour, ICameraService
    {
        [field: SerializeField] public CinemachineVirtualCamera PlayerCamera { get; private set; }
        [field: SerializeField] public CinemachineVirtualCamera SceneCamera { get; private set; }

        private void OnEnable()
        {
            ServiceLocator.Register<ICameraService>(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Unregister<ICameraService>();
        }

        public void AssignPlayerCamera(Transform targetToFollow)
        {
            PlayerCamera.Follow = targetToFollow;

            // TODOMK Hardcoding priority is fine for now, more advanced system might be needed later.
            PlayerCamera.Priority = 10;
            SceneCamera.Priority = 9;
        }

        public void UnassignPlayerCamera()
        {
            PlayerCamera.Priority = 9;
            SceneCamera.Priority = 10;
        }
    }
}