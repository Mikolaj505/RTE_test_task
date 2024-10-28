using Fusion;
using Fusion.Addons.KCC;
using System;
using UnityEngine;
using ToolBox.Pools;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballController : NetworkBehaviour
    {
        [SerializeField] private AnimationCurve _forwardVelocityCurve;
        [SerializeField] private float _velocityEvaluationDuration;
        [SerializeField] private float _velocity;
        [SerializeField] private float _gravityEffectWeight = 0.5f;
        [SerializeField] private int _maxRaycastHitsChecked = 15;

        [SerializeField] private GameObject _puffVFX;

        private float _damageToDeal;
        private Vector3 _gravityVelocity;
        private TickTimer FlightTimer { get; set; }

        private RaycastHit[] _hitResults;

        private void Awake()
        {
            _hitResults = new RaycastHit[_maxRaycastHitsChecked];
        }

        public void Fire(float damage)
        {
            _damageToDeal = damage;
            FlightTimer = TickTimer.CreateFromSeconds(Runner, _velocityEvaluationDuration);
        }

        public override void FixedUpdateNetwork()
        {
            UpdateThrownState();
        }

        private void UpdateThrownState()
        {
            var flightProgress = Mathf.InverseLerp(0, _velocityEvaluationDuration, _velocityEvaluationDuration - FlightTimer.RemainingTime(Runner) ?? 0);
            var evaluatedVelocityFactor = _forwardVelocityCurve.Evaluate(flightProgress);

            var previousPosition = transform.position;

            var currentTickVelocity = _velocity * evaluatedVelocityFactor;
            _gravityVelocity += Physics.gravity * _gravityEffectWeight * Runner.DeltaTime;
            transform.position += (currentTickVelocity * transform.forward * Runner.DeltaTime) + _gravityVelocity;

            var newPosition = transform.position;

            UpdateMidFlightCollisions(previousPosition, newPosition);
        }

        private void UpdateMidFlightCollisions(Vector3 previousPosition, Vector3 newPosition)
        {
            if (Runner.IsServer == false)
            {
                return;
            }

            var hitCount = RaycastExtensions.CheckForCollisionsSorted(previousPosition, newPosition, _hitResults);
            if (hitCount > 0)
            {
                var player = _hitResults[0].collider.GetComponentNoAlloc<PlayerFacade>();
                if (player != null)
                {
                    player.Health.TakeDamage(_damageToDeal, Object.InputAuthority);
                }
                else
                {
                    //Hit something else, for now, do nothing with it.
                }

                Runner.Despawn(Object);
            }
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
        {
            _puffVFX.Reuse(transform.position, Quaternion.identity);
        }
    }
}