using e.Features;
using e.Features.Misc;
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
        public override void OnApplicationStart()
        {
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F1)) 
            {
                Gui.ToggleMenu();
            }

            Features.Aimbot.Aimbot.Loop();

            Features.Misc.NightMode.Loop();
            Features.Misc.RainbowSky.Loop(); //might change the viusals stuff like nightmode and rainbow sky to Visuals
            Features.Misc.ChatSpam.Loop();

            Features.Visuals.Fov.Loop();

            Network.Loop();
            LongNeck.Loop();

            Testing.Loop();
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
    }
}
