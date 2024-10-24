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

        private TickTimer FlightTimer { get; set; }

        private RaycastHit[] _hitResults;

        private enum SnowballState
        {
            None,
            Thrown,
            Hit,
        }

        private SnowballState State { get; set; }

        private void Awake()
        {
            _hitResults = new RaycastHit[_maxRaycastHitsChecked];
        }

        public void Fire()
        {
            State = SnowballState.Thrown;
            FlightTimer = TickTimer.CreateFromSeconds(Runner, _velocityEvaluationDuration);
        }

        public override void FixedUpdateNetwork()
        {
            switch (State)
            {
                case SnowballState.None:
                    break;
                case SnowballState.Thrown:
                    UpdateThrownState();
                    break;
                case SnowballState.Hit:
                    break;
            }
        }

        public void UpdateThrownState()
        {
            var flightProgress = Mathf.InverseLerp(0, _velocityEvaluationDuration, _velocityEvaluationDuration - FlightTimer.RemainingTime(Runner) ?? 0);
            var evaluatedVelocityFactor = _forwardVelocityCurve.Evaluate(flightProgress);

            var previousPosition = transform.position;

            var currentTickVelocity = _velocity * evaluatedVelocityFactor;
            transform.position += currentTickVelocity * transform.forward * Runner.DeltaTime;
            transform.position += Physics.gravity * _gravityEffectWeight * Runner.DeltaTime;

            var newPosition = transform.position;

            CheckForCollisions(previousPosition, newPosition, _hitResults);
        }

        /// <summary>
        /// More reliable than OnCollisionEnter, as the other might miss colliisions. 
        /// Also, commonly used in gamedev for that reason. 
        /// It's raycasting from previous position to current and checking if it had any collisions since last position update.
        /// </summary>
        /// <param name="previousPosition"></param>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        private bool CheckForCollisions(Vector3 previousPosition, Vector3 currentPosition, RaycastHit[] hitResults)
        {
            Vector3 direction = currentPosition - previousPosition;
            float distance = direction.magnitude;

            int hitCount = Physics.RaycastNonAlloc(previousPosition, direction, hitResults, distance);

            if (hitCount == 0)
            {
                return false;
            }

            RaycastHit[] notNullRaycastHits = new RaycastHit[hitCount];
            int notNullCollidersIdx = 0;
            for (int i = 0; i < hitResults.Length; i++) 
            {
                if (hitResults[i].collider != null)
                {
                    notNullRaycastHits[notNullCollidersIdx] = hitResults[i];
                    notNullCollidersIdx++;
                }
            }

            // Sort the hits based on distance from previousPosition.
            Array.Sort(notNullRaycastHits, (a, b) => a.distance.CompareTo(b.distance));
            var firstHit = notNullRaycastHits[0];

            var player = firstHit.collider.GetComponentNoAlloc<PlayerFacade>();
            if (player != null)
            {
                Debug.Log($"Hit Player!!!");
            }
            else
            {
                Debug.Log($"Hit something else {firstHit.collider.gameObject.name}");
            }

            return true;
        }
    }
}