using UnityEngine;

namespace MKubiak.RTETestTask.PlayerUI
{
    public class PlayerMenuPositioner : MonoBehaviour
    {
        [SerializeField] private Vector3 _localSpaceOffset;

        public void Position(PlayerFacade player)
        {
            if (player == null)
            {
                return;
            }

            var targetTransform = player.Head;

            Vector3 offsetInWorldSpace =
                   targetTransform.right * _localSpaceOffset.x +
                   targetTransform.up * _localSpaceOffset.y +
                   targetTransform.forward * _localSpaceOffset.z;

            transform.position = targetTransform.position + offsetInWorldSpace;
        }
    }
}