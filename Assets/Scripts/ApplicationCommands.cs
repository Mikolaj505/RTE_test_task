using IngameDebugConsole;
using UnityEngine;

namespace MKubiak.RTETestTask.Test
{
    public static class ApplicationCommands
    {
        [ConsoleMethod("targetframerate.set", "Caps FPS to value")]
        public static void SetTargetFramerate(int targetFrameRate)
        {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}