using e.Utilities;
using Il2CppSystem.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace e.Features
{
    internal class Network
    {
        public static uint MaxPing = 100; // max ping limit
        public static bool bMaxPing = false; // this enables ping warnings
        public static bool HighPingNotificationSent = false;
        public static int PingHits = 0; // the amount that the ping has been over the max limit // this is not yet being used it will continue to count up

        public static void Loop()
        {
            if (Controll.ping > MaxPing && bMaxPing && !HighPingNotificationSent)
            {
                Logger.LogError("Max Ping hit!");
                PingHits++;
                HighPingNotificationSent = true;
            }

            if (Controll.ping <= MaxPing)
            {
                HighPingNotificationSent = false;
            }
        }
    }
}
