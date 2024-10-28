using UnityEngine;

namespace MKubiak.RTETestTask
{
    public interface ICameraService
    {
        void AssignPlayerCamera(Transform targetToFollow);
        void UnassignPlayerCamera();
    }
}