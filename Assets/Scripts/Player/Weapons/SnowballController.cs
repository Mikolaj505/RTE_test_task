using Fusion;
using Fusion.Addons.KCC;
using System;
using UnityEngine;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballController : NetworkBehaviour
    {
        [SerializeField] private AnimationCurve _forwardVelocityCurve;
        [SerializeField] private float _velocityEvaluationDuration;
        [SerializeField] private float _velocity;
        [SerializeField][Range(0, 1)] private float _gravityEffectWeight = 0.5f;
        [SerializeField] private int _maxRaycastHitsChecked = 15;

        private float _damageToDeal;

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
            transform.position += currentTickVelocity * transform.forward * Runner.DeltaTime;
            transform.position += Physics.gravity * _gravityEffectWeight * Runner.DeltaTime;

            var newPosition = transform.position;

            UpdateMidFlightCollisions(previousPosition, newPosition);
        }

        private void UpdateMidFlightCollisions(Vector3 previousPosition, Vector3 newPosition)
        {
            if (Runner.IsServer == false)
            {
                return;
            }

            var hitCollider = RaycastExtensions.CheckForCollisionsSorted(previousPosition, newPosition, _hitResults);
            if (hitCollider != null)
            {
                var player = hitCollider.GetComponentNoAlloc<PlayerFacade>();
                if (player != null)
                {
                    player.Health.TakeDamage(_damageToDeal, Object.InputAuthority);
                }
                else
                {
                    Debug.Log($"Hit something else {hitCollider.gameObject.name}");
                }

                Runner.Despawn(Object);
            }
        }
    }
}