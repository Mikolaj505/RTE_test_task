using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class TransformFollower : MonoBehaviour
    {
        [field: SerializeField] public Transform TargetTransform { get; set; }
        [SerializeField] private Vector3 _localSpaceOffset;

        private void LateUpdate()
        {
            if (TargetTransform != null)
            {
                Vector3 offsetInWorldSpace =
                    TargetTransform.right * _localSpaceOffset.x +
                    TargetTransform.up * _localSpaceOffset.y +
                    TargetTransform.forward * _localSpaceOffset.z;

                transform.position = TargetTransform.position + offsetInWorldSpace;
            }
        }
    }
}
