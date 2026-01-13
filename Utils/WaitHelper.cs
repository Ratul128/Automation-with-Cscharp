using System;
using System.Threading;

namespace LoginAutomationTest.Utils
{
    public static class WaitHelper
    {
        public static void Wait(int seconds = 1)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
