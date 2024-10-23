namespace MKubiak.RTETestTask.Input
{
    public static class PlayerInputExtensions
    {
        public static bool IsActive(this PlayerInputAction action, PlayerInput input)
        {
            return input.Actions.IsSet(action);
        }

        public static bool WasActivated(this PlayerInputAction action, PlayerInput currentInput, PlayerInput previousInput)
        {
            return currentInput.Actions.IsSet(action) && previousInput.Actions.IsSet(action) == false;
        }

        public static bool WasDeactivated(this PlayerInputAction action, PlayerInput currentInput, PlayerInput previousInput)
        {
            return currentInput.Actions.IsSet(action) == false && previousInput.Actions.IsSet(action);
        }
    }
}
