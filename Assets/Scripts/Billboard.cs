using UnityEngine;

namespace MKubiak.RTETestTask
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Camera _targetCamera;

        void Start()
        {
            if (_targetCamera == null)
            {
                _targetCamera = Camera.main;
            }
        }

        void LateUpdate()
        {
            if (_targetCamera != null)
            {
                Vector3 direction = _targetCamera.transform.position - transform.position;

                transform.rotation = Quaternion.LookRotation(-direction);
            }
        }
    }
}
