using Fusion;
using UnityEngine;

namespace MKubiak.RTETestTask.Weapons
{
    public class SnowballController : NetworkBehaviour
    {
        [SerializeField] private AnimationCurve _forwardVelocityCurve;
        [SerializeField] private float _velocityEvaluationDuration;
        [SerializeField] private float _velocity;
        [SerializeField][Range(0, 1)] private float _gravityEffectWeight = 0.5f;

        private TickTimer FlightTimer { get; set; }

        private enum SnowballState
        {
            None,
            Thrown,
            Hit,
        }

        private SnowballState State { get; set; }

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

            var currentTickVelocity = _velocity * evaluatedVelocityFactor;
            transform.position += currentTickVelocity * transform.forward * Runner.DeltaTime;
            transform.position += Physics.gravity * _gravityEffectWeight * Runner.DeltaTime;
        }
    }
}