using e.Features;
using e.Features.Aimbot;
using e.Features.Visuals;
using MelonLoader;
using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;

namespace e
{
    internal class Gui
    {
        public static Rect WRect = new Rect(320, 120, 500, 400);

        private static int selectedTab = -0;
        public static bool showMenu = false;
        public static bool HUD = true;

        public static PlayerData selectedPlayer = null;

        public static void ToggleMenu()
        {
            showMenu = !showMenu;
        }
        private static void DisplayHud()
        {
            GUIStyle guistyle = new GUIStyle();
            guistyle.fontSize = 15;
            guistyle.richText = true;
            guistyle.fontStyle = (FontStyle)6;
            guistyle.wordWrap = false;
            guistyle.normal.textColor = Color.white;
            GUI.Label(new Rect(0f, 0f, 300f, 50f), "<color=#0b03fc>U</color> <color=#84fc03>w</color> <color=#0b03fc>U</color>", guistyle);
        }
        public static void Main()
        {
            if (HUD) { DisplayHud(); }
            GUI.color = new Color(1f, 1f, 1f, 0f);
            if (showMenu) { WRect = GUI.Window(0, WRect, (GUI.WindowFunction)DrawMenu, "e"); }

        }

        public static void DrawMenu(int windowID)
        {
            GUI.backgroundColor = Color.black;
            GUI.BeginGroup(new Rect(10, 10, 500, 400));

            GUI.contentColor = Color.yellow;
            GUI.Box(new Rect(0, 0, 500, 400), "e");
            GUI.contentColor = Color.white;

            if (GUI.Button(new Rect(20, 40, 60, 20), (selectedTab == -1) ? "[Home]" : "Home")) { selectedTab = -1; }
            if (GUI.Button(new Rect(90, 40, 60, 20), (selectedTab == 0) ? "[AIM]" : "AIM")) { selectedTab = 0; }
            if (GUI.Button(new Rect(160, 40, 60, 20), (selectedTab == 1) ? "[ESP]" : "ESP")) { selectedTab = 1; }
            if (GUI.Button(new Rect(230, 40, 60, 20), (selectedTab == 2) ? "[Misc]" : "Misc")) { selectedTab = 2; }
            if (GUI.Button(new Rect(300, 40, 60, 20), (selectedTab == 3) ? "[Info]" : "Info")) { selectedTab = 3; }
            if (GUI.Button(new Rect(370, 40, 60, 20), (selectedTab == 3) ? "[Players]" : "Players")) { selectedTab = 4; }

            GUI.backgroundColor = Color.white;

            switch (selectedTab)
            {
                case -1: HomeTab(); break;
                case 0: AimTab(); break;
                case 1: ESPTab(); break;
                case 2: MiscTab(); break;
                case 3: InfoTab(); break;
                case 4: PlayersTab(); break;
            }

            GUI.EndGroup();
            GUI.DragWindow();
        }

        #region TABS
        private static Vector2 scrollPosition = Vector2.zero;
     
        private static void HomeTab()
        {
        }
        private static void AimTab()
        {
            Aimbot.enabled = GUI.Toggle(new Rect(10, 75, 65, 20), Aimbot.enabled, "Aimbot");

            GUI.Label(new Rect(90, 65, 150, 20), $"FOV ({Aimbot.Fov.ToString()})");
            Aimbot.Fov = GUI.HorizontalSlider(new Rect(90, 82, 250, 20), Aimbot.Fov, 0, 1000);

            Aimbot.teamCheckEnabled = GUI.Toggle(new Rect(10, 100, 65, 20), Aimbot.teamCheckEnabled, "Team");
            Aimbot.checkForSpawnProtection = GUI.Toggle(new Rect(10, 120, 85, 20), Aimbot.checkForSpawnProtection, "SpawnProtect");
        }
        private static void ESPTab()
        {
            GUI.Label(new Rect(20, 65, 400, 20), $"FOV ({Fov.fFOV.ToString()})");
            Fov.fFOV = GUI.HorizontalSlider(new Rect(20, 82, 150, 20), Fov.fFOV, 60, 140);

            GUI.Label(new Rect(20, 93, 400, 20), $"Aspect ({Fov.fAspect.ToString()})");
            Fov.fAspect = GUI.HorizontalSlider(new Rect(20, 110, 150, 20), Fov.fAspect, 0.5f, 1.7778f);

            GUI.Label(new Rect(10, 130, 200, 20), $"-----Visuals-----");
            ESP.BoxEsp = GUI.Toggle(new Rect(10, 150, 65, 20), ESP.BoxEsp, "Box");
            ESP.LineEsp = GUI.Toggle(new Rect(10, 170, 65, 20), ESP.LineEsp, "Line");
            ESP.Team = GUI.Toggle(new Rect(10, 190, 65, 20), ESP.Team, "Team");
            ESP.HealthEsp = GUI.Toggle(new Rect(10, 210, 65, 20), ESP.HealthEsp, "Health");
            ESP.NameEsp = GUI.Toggle(new Rect(10, 230, 65, 20), ESP.NameEsp, "Name");

            GUI.Label(new Rect(100, 130, 200, 20), $"-----World-----");
            Features.Misc.NightMode.bNight = GUI.Toggle(new Rect(100, 150, 80, 20), Features.Misc.NightMode.bNight, "NightMode");
            Features.Misc.RainbowSky.bRainbow = GUI.Toggle(new Rect(100, 170, 65, 20), Features.Misc.RainbowSky.bRainbow, "Rainbow Sky");
        }
        private static void MiscTab()
        {
            Features.Misc.ChatSpam.bSpam = GUI.Toggle(new Rect(10, 75, 85, 20), Features.Misc.ChatSpam.bSpam, "Chat Spam");
        }
        private static void InfoTab()
        {
            Network.bMaxPing = GUI.Toggle(new Rect(10, 70, 65, 20), Network.bMaxPing, "");
            GUI.Label(new Rect(35, 70, 400, 20), $"Ping Limit: ({Network.MaxPing})");
            Network.MaxPing = (uint)GUI.HorizontalSlider(new Rect(10, 90, 200, 20), Network.MaxPing, 5, 1000);

            GUI.Label(new Rect(10, 130, 200, 20), $"-----Local-----");
            GUI.Label(new Rect(10, 150, 200, 20), $"Name: ({Controll.pl.name})");
            GUI.Label(new Rect(10, 170, 200, 20), $"Pos: ({Controll.currPos.ToString()})");
            GUI.Label(new Rect(10, 190, 200, 20), $"Rot: ({Controll.pl.currRot})");
            GUI.Label(new Rect(10, 210, 200, 20), $"Weapon: ({Controll.pl.currweapon})");

            GUI.Label(new Rect(200, 130, 200, 20), $"-----Network-----");
            if(Controll.ping > Network.MaxPing) {
                GUI.Label(new Rect(200, 150, 200, 20), $"Ping: <color=red>({Controll.ping})</color>");
            } else {
                GUI.Label(new Rect(200, 150, 200, 20), $"Ping: <color=green>({Controll.ping})</color>");
            }
           
            GUI.Label(new Rect(200, 170, 200, 20), $"Server IP: ({MasterClient.IP})");
            GUI.Label(new Rect(200, 190, 200, 20), $"Local IP: ({Client.IP})");

        }
        private static void PlayerTab(PlayerData ply)
        {
            GUI.Label(new Rect(20, 70, 500, 20), $"Selected player: {ply.name}");
            GUI.Label(new Rect(20, 90, 500, 20), $"Position: {ply.Pos.ToString()}");
            GUI.Label(new Rect(20, 105, 500, 20), $"Rotation: {ply.currRot.ToString()}");
            GUI.Label(new Rect(20, 125, 500, 20), $"Weapon: {ply.currweapon.weaponname.ToString()}");

            if (GUI.Button(new Rect(20, 205, 200, 20), "Back"))
            {
                selectedPlayer = null;
            }
        }
        private static void PlayersTab()
        {
            if (selectedPlayer == null)
            {
                float localOffset = 70;
                Il2CppReferenceArray<PlayerData> players = PLH.player;
                scrollPosition = GUI.BeginScrollView(new Rect(10, 75, 450, 300), scrollPosition, new Rect(0, 0, 300, 1500));
                foreach (PlayerData player in players)
                {

                    if (player == null)
                    {
                        continue;
                    }

                    if (GUI.Button(new Rect(20, localOffset, 300, 20), $"{player?.name.ToString()}")) // Use GUILayout to create the button
                    {
                        MelonLogger.Msg($"Selecting player {player?.name.ToString()}.");
                        selectedPlayer = player;
                    }
                    localOffset += 20;
                }
                GUI.EndScrollView();
            }
            else
            {
                PlayerTab(selectedPlayer);
            }
        }
        #endregion
    }
}
