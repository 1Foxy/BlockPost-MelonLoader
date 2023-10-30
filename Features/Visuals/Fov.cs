using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace e.Features.Visuals
{
    internal class Fov
    {
        public static float fFOV = 65;
        public static float fAspect = 1.7778f;
        public static Camera LocalCamera;

        public static void Loop()
        {
            GameObject cameraObject = GameObject.Find("Controll/Camera");
            if (cameraObject != null)
            {
                LocalCamera = cameraObject.GetComponent<Camera>();
                LocalCamera.fieldOfView = fFOV;
                LocalCamera.aspect = fAspect; //0.7 best gaming mode wide putin
            }
        }
    }
}
