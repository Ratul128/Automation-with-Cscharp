using System;
using System.Threading;

namespace LoginAutomationTest.Utils
{
    public static class WaitHelper
    {
        // Simple static wait in seconds
        public static void Wait(int seconds = 1)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
