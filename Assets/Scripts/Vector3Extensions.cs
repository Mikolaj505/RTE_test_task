using UnityEngine;

namespace MKubiak.RTETestTask
{
    public static class TransformExtensions
    {
        public static Vector3 GetPositionWithLocalSpaceOffest(this Transform transform, Vector3 localSpaceOffest)
        {
            Vector3 offsetInWorldSpace =
                    transform.right * localSpaceOffest.x +
                    transform.up * localSpaceOffest.y +
                    transform.forward * localSpaceOffest.z;

            return transform.position + offsetInWorldSpace;
        }
    }
}
