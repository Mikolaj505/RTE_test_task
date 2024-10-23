namespace MKubiak.RTETestTask
{
    public class Throttle
    {
        private float _throttleInterval;
        private float? _lastTimeUsed;

        public Throttle(float throttleInterval, float? lastTimeUsed = null)
        {
            _throttleInterval = throttleInterval;
            _lastTimeUsed = lastTimeUsed;
        }

        public bool IsReadyToUse(float time)
        {
            if (_lastTimeUsed == null)
            {
                _lastTimeUsed = time;
                return true;
            }
            if (time > _lastTimeUsed + _throttleInterval)
            {
                _lastTimeUsed = time;
                return true;
            }

            return false;
        }
    }
}
