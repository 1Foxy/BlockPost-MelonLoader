using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngineInternal;

namespace e.Features.Visuals
{
    public class ESP
    {
        public static bool NameEsp = false;
        public static bool WeaponEsp = false;
        public static bool HealthEsp = false;
        public static bool BoxEsp = false;
        public static bool Team = false;
        public static bool LineEsp = false;


        public static void DrawESP()
        {
            PlayerData pl = Controll.pl;
            Camera csCam = Controll.csCam;
            Vector3 currPos = Controll.currPos;
            Il2CppReferenceArray<PlayerData> players = PLH.player;

            if (pl == null)
            {
                string text1;
                if (pl != null)
                {
                    text1 = pl.ToString();
                }
                else
                {
                    PlayerData local1 = pl;
                    text1 = null;
                }
            }
            foreach (PlayerData data2 in players)
            {
                if ((data2 != null) && ((data2.health > 10) && (pl.name != data2.name)))
                {
                    Vector3 vector3;
                    Vector3 position = data2.tr.position;
                    Vector3 vector2 = data2.rbHead.position;
                    vector3.x = position.x;
                    vector3.z = position.z;
                    vector3.y = position.y - 2.1f;
                    Vector3 vector4 = new Vector3(vector2.x, vector2.y + 0.7f, vector2.z);
                    Vector3 vector6 = csCam.WorldToScreenPoint(vector4);
                    Vector3 vector7 = csCam.WorldToScreenPoint(vector3);
                    if (csCam.WorldToScreenPoint(position).z > 0f)
                    {
                        float h = vector6.y - vector7.y;
                        float w = h / 2f;
                        Rect rect = new Rect(vector6.x - 20f, (Screen.height - vector6.y) - 15f, 200f, 50f);
                        Rect rect2 = new Rect(vector7.x - 15f, (Screen.height - vector7.y) + 3f, 200f, 50f);
                        Rect rect3 = new Rect(vector6.x - 20f, (Screen.height - vector6.y) - 0x19f, 200f, 50f);
                        bool flag = data2.team == pl.team;
                        GUIStyle style = new GUIStyle
                        {
                            normal = { textColor = Color.white },
                            fontSize = 10,
                            fontStyle = FontStyle.Bold
                        };
                        if (NameEsp)
                        {
                            GUI.Label(rect, data2.name, style);
                        }
                        if (WeaponEsp)
                        {
                            GUI.Label(rect3, "[weapon]" + data2.currweapon.weaponname, style);
                        }
                        if (HealthEsp)
                        {
                            GUI.Label(rect2, "[HP]:" + ((int)data2.health).ToString(), style);
                        }
                        if (BoxEsp)
                        {
                            if (flag)
                            {
                                if (Team)
                                {
                                    Render.DrawBox(vector7.x - (w / 2f), (Screen.height - vector7.y) - h, w, h, Color.green, 1f);

                                }
                            }
                            else
                            {
                                Render.DrawBox(vector7.x - (w / 2f), (Screen.height - vector7.y) - h, w, h, Color.red, 1f);
                            }
                        }
                        if (LineEsp)
                        {
                            if (!Team)
                            {
                                Render.DrawLine(new Vector2((float)Screen.height, (float)Screen.height), new Vector2(vector7.x, Screen.height - vector7.y), Color.red, 1f);
                            }
                            else if (!flag)
                            {
                                Render.DrawLine(new Vector2((float)Screen.height, (float)Screen.height), new Vector2(vector7.x, Screen.height - vector7.y), Color.red, 1f);
                            }
                            else
                            {
                                Render.DrawLine(new Vector2((float)Screen.height, (float)Screen.height), new Vector2(vector7.x, Screen.height - vector7.y), Color.white, 1f);
                            }
                        }
                    }
                }
            }
        }




        //public void UiScale()
        //{
        //    uiManager = GetComponent<UIManager>();
        //    UIManager.CanvasMenu.scaleFactor = 1;
        //}
    }
}
