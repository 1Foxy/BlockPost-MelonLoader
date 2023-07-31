using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace e.Features.Misc
{
    internal class NightMode
    {
        public static bool bNight = false;

        public static void Loop()
        {
            Night_Mode();
        }

        public static void Night_Mode()
        {
            GameObject cameraObject = GameObject.Find("Dlight");
            if (cameraObject != null)
            {
                Light light = null;
                light = cameraObject.GetComponent<Light>();
                if (bNight)
                {
                    light.enabled = false;
                }
                else { light.enabled = true; }

            }
        }
    }
}
