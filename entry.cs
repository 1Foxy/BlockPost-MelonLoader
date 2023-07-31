using e.Features.Visuals;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;

[assembly: MelonInfo(typeof(e.entry), "e", "1.0.1", "e")]

namespace e
{
    internal class entry : MelonMod
    {
        private static bool isInitialized;

        public override void OnApplicationStart()
        {
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Home))
            {
                Gui.ToggleMenu();
            }

            Features.Aimbot.Aimbot.Loop();
            Features.Misc.UnlimtedAmmo.Loop();
            Features.Misc.NightMode.Loop();
            Features.Visuals.Fov.Loop();

        }

        public override void OnLevelWasLoaded(int level)
        {
        }

        public override void OnGUI()
        {
            Gui.Main();
            ESP.DrawESP();

        }

        public override void OnLateUpdate()
        {
        }

        public override void OnApplicationQuit()
        {
        }

        public static void Initialize()
        {
            if (isInitialized)
            {
                return;
            }

          

            isInitialized = true;

            MelonLogger.Msg("Init: " + isInitialized);
        }
    }
}
