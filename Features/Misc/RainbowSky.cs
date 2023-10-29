using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace e.Features.Misc
{
    internal class RainbowSky
    {

        public static bool bRainbow = false;


        public static float colorChangeSpeed = 1.0f; // Adjust the speed of the color change
        public static Color[] rainbowColors = new Color[]
        {
        Color.red,
        new Color(1.0f, 0.65f, 0.0f), // Orange
        Color.yellow,
        Color.green,
        Color.blue,
        Color.magenta
        };
        public static int currentColorIndex = 0;
        public static float t = 0.0f;

        public static void Loop()
        {
            Rainbow();
        }

        public static void Rainbow()
        {
            GameObject cameraObject = GameObject.Find("Dlight");

            if (cameraObject != null)
            {
                Light light = cameraObject.GetComponent<Light>();


                if (bRainbow)
                {
                    t += Time.deltaTime * colorChangeSpeed;

                    if (t >= 1.0f)
                    {
                        t = 0.0f;
                        currentColorIndex = (currentColorIndex + 1) % rainbowColors.Length;
                    }

                    Color startColor = rainbowColors[currentColorIndex];
                    Color endColor = rainbowColors[(currentColorIndex + 1) % rainbowColors.Length];

                    light.color = Color.Lerp(startColor, endColor, t);
                }
                else
                {
                    light.color = Color.white;
                }
            }
        }
    }
}
