using UnityEngine;
using ToolBox.Pools;
using System.Collections;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballPuffEffectController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _puffVFX;
        [SerializeField] private float _playDuration = 3;

        private void OnEnable()
        {
            _puffVFX.Play();
            StartCoroutine(DespawnRoutine());
        }

        private IEnumerator DespawnRoutine()
        {
            yield return new WaitForSeconds(_playDuration);
            gameObject.Release();
        }
    }
}