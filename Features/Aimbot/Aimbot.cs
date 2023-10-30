using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e.Features.Aimbot
{
    using System;
    using UnhollowerBaseLib;
    using UnityEngine;
    using Player;
    using System.Runtime.InteropServices;


    public class Aimbot
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(Int32 dwFlags, Int32 dx, Int32 dy, Int32 dwData, Int32 dwExtraInfo);
        public static Vector2 vectorToAimAt = Vector2.zero;
        public static Boolean teamCheckEnabled = false;
        public static Boolean checkForSpawnProtection = true;
        public static bool enabled = false;
        public static float Fov = 1000;
        public static float smooth = 3.5f;

        public static void Loop()
        {
            if (enabled)
            {
                GetTargetToAimAt();

                AimAtTarget();
            }
        }

       

        public static void AimAtTarget()
        {
            Boolean aimIsNotZero = vectorToAimAt != Vector2.zero;

            if (aimIsNotZero)
            {
                Double dx = vectorToAimAt.x - (Screen.width / 2.0f);
                Double dy = vectorToAimAt.y - (Screen.height / 2.0f);
                dx = dx /= smooth;
                dy = dy /= smooth;

                KeyCode aimbotKey = KeyCode.Mouse1;
                Boolean aimbotKeyHeld = Input.GetKey(aimbotKey);

                if (aimbotKeyHeld)
                {
                    mouse_event(0x0001, (Int32)dx, (Int32)dy, 0, 0);
                }
            }
        }
        public static void GetTargetToAimAt()
        {
            Il2CppReferenceArray<PlayerData> players = PLH.player;
            PlayerData localPlayer = Controll.pl;
            Camera localPlayerCamera = Controll.csCam;

            Vector3 localPlayerPosition = Controll.currPos;

            Single minPlayerDist = Single.MaxValue;

            foreach (PlayerData player in players)
            {
                Boolean nullPlayer = player == null;

                if (!nullPlayer)
                {
                    Vector3 playerPostion = player.rbHead.position;
                    Single headOffsetX = playerPostion.x;
                    Single headOffsetY = playerPostion.y + 0.47f;
                    Single headOffsetZ = playerPostion.z;
                    Vector3 playerPositionOffset = new Vector3(headOffsetX, headOffsetY, headOffsetZ);
                    Vector3 worldToScreenPoint = localPlayerCamera.WorldToScreenPoint(playerPositionOffset);

                    Boolean isTeam = player.team == localPlayer.team;
                    Boolean isPlayersOnScreenVisible = player.visible;
                    Boolean isSpawnProtected = player.spawnprotect;

                    Int32 playerHealth = player.health;

                    // Conditionally check for isSpawnProtected
                    Boolean playerChecking = playerHealth > 10 && (!checkForSpawnProtection || !player.spawnprotect) && player.name != localPlayer.name;
                    Boolean isPlayerOnScreen = worldToScreenPoint.z > 0.00f;
                    Boolean aimbotChecking = playerChecking && isPlayerOnScreen;

                    String playerName = player.name;
                    String playerClanName = player.clanname;

                    if (aimbotChecking)
                    {
                        Vector2 a = new Vector2(worldToScreenPoint.x, Screen.height - worldToScreenPoint.y);
                        Vector2 screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
                        Single distFromCentre = Math.Abs(Vector2.Distance(a, screenCentre));
                        Boolean isPlayerInMinDist = distFromCentre < minPlayerDist;

                        if (distFromCentre < Fov && isPlayerInMinDist)
                        {
                            if (isTeam)
                            {
                                if(teamCheckEnabled)
                                {
                                    minPlayerDist = distFromCentre;
                                    vectorToAimAt = new Vector2(worldToScreenPoint.x, Screen.height - worldToScreenPoint.y);
                                }
                            }
                            else
                            {
                                minPlayerDist = distFromCentre;
                                vectorToAimAt = new Vector2(worldToScreenPoint.x, Screen.height - worldToScreenPoint.y);
                            }
 
                        }
                    }
                }
            }
        }
        public static void VisibleAimbot()
        {
            try
            {
                Il2CppReferenceArray<PlayerData> players = PLH.player; // All the players in the game

                PlayerData localPlayer = Controll.pl; // My local player
                Camera localPlayerCamera = Controll.csCam; // My local player camera
                Vector3 localPlayerPosition = Controll.currPos; // My local player current position

                foreach (PlayerData player in players)
                {
                    if (player == null || player == localPlayer || player.team == localPlayer.team)
                    {
                        continue;
                    }

                    Single distance = Vector3.Distance(localPlayerPosition, player.currPos);
                    Single maxDistance = Single.MaxValue;
                    Single minDistance = 0.000f;
                    if (distance < maxDistance && distance > minDistance)
                    {
                        localPlayerCamera.transform.LookAt(player.rbHead.position);
                    }

                    Ray ray = localPlayerCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(ray, out raycastHit, Single.PositiveInfinity))
                    {
                        if (raycastHit.transform.name == "Map" || raycastHit.transform.name == "MapBackPlatform" ||
                            raycastHit.transform.name == "body" || raycastHit.transform.name == "RightArmUp" ||
                            raycastHit.transform.name == "RightArmDown" ||
                            raycastHit.transform.name == "LeftArmUp" || raycastHit.transform.name == "LeftArmDown" ||
                            raycastHit.transform.name == "RightLegUp" || raycastHit.transform.name == "RightLegDown" ||
                            raycastHit.transform.name == "LeftLegUp" || raycastHit.transform.name == "LeftLegDown" ||
                            raycastHit.transform.name == "RightLegBoot" || raycastHit.transform.name == "LeftLegBoot" ||
                            raycastHit.transform.name.Contains("p_weapon") == true)
                        {
                            continue;
                        }
                        if (raycastHit.transform.name == "head")
                        {
                            localPlayerCamera.transform.LookAt(raycastHit.rigidbody.position);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public static Boolean IsVisible(Vector3 origin, Vector3 toCheck)
        {
            RaycastHit hit;

            if (Physics.Linecast(origin, toCheck, out hit))
            {
                foreach (PlayerData player in PLH.player)
                {
                    PlayerData localPlayer = Controll.pl; // My local player

                    if (player == null || player == localPlayer)
                    {
                        continue;
                    }

                    if (hit.transform.name.Contains("Map") || hit.transform.name == "MapBackPlatform" || hit.transform.name.Contains("p_weapon"))
                    {
                        continue;
                    }

                    if (hit.transform.name.Contains("head") || hit.transform.name.Contains("body") || hit.transform.name == "RightArmUp" || hit.transform.name == "RightArmDown" || hit.transform.name == "LeftArmUp" || hit.transform.name == "LeftArmDown" || hit.transform.name == "RightLegUp" || hit.transform.name == "RightLegDown" || hit.transform.name == "LeftLegUp" || hit.transform.name == "LeftLegDown" || hit.transform.name == "RightLegBoot" || hit.transform.name == "LeftLegBoot" || hit.transform.name == player.tr.name || hit.transform.name == player.tr.gameObject.name || hit.transform.name == player.go.transform.name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static Boolean IsInCross()
        {
            Il2CppReferenceArray<PlayerData> players = PLH.player;


            PlayerData localPlayer = Controll.pl;
            Camera localPlayerCamera = Controll.csCam;
            Vector3 localPlayerPosition = Controll.currPos;

            foreach (PlayerData player in players)
            {
                if (player == null || player == localPlayer)
                {
                    continue;
                }

                Boolean isTeam = player.team == localPlayer.team;

                Ray ray = localPlayerCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit, Single.PositiveInfinity))
                {
                    if (raycastHit.transform.name == "Map" || raycastHit.transform.name == "MapBackPlatform" || raycastHit.transform.name.Contains("p_weapon"))
                    {
                        continue;
                    }
                    if (raycastHit.transform.name is "head" or "body" or "RightArmUp" or "RightArmDown" or "LeftArmUp" or "LeftArmDown" or "RightLegUp" or "RightLegDown" or "LeftLegUp" or "LeftLegDown" or "RightLegBoot" or "LeftLegBoot")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}
