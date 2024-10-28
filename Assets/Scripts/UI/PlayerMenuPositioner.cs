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
            transform.position = targetTransform.GetPositionWithLocalSpaceOffest(_localSpaceOffset);
        }
    }
}